using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Dapper;
using HaloOnline.Server.Core.Http.Model.Messaging;
using HaloOnline.Server.Core.Http.Model;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [Authorize]
    public class MessagingController : ApiController
    {
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        public async Task<IHttpActionResult> LeaveChannels([FromBody] LeaveChannelsRequest request)
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                await UpdateUserColumnsAsync(userId);

                var channels = await GetChannelInfoFromDatabaseAsync(userId);

                foreach (var channelName in request.ChannelNames)
                {
                    channels.RemoveAll(channel => channel.Name == channelName);
                }

                var result = new
                {
                    LeaveChannelsResult = new
                    {
                        retCode = 0,
                        data = channels
                    }
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private async Task UpdateUserColumnsAsync(int userId)
        {
            using (var connection = await GetOpenConnectionAsync())
            {
                await connection.ExecuteAsync(
                    "UPDATE User SET State = 1, IsInvitable = 1 WHERE Id = @UserId",
                    new { UserId = userId }
                );
            }
        }

        private async Task<List<ChannelInfo>> GetChannelInfoFromDatabaseAsync(int userId)
        {
            var channelInfoList = new List<ChannelInfo>();

            using (var connection = await GetOpenConnectionAsync())
            {
                var channels = await connection.QueryAsync<dynamic>(
                    "SELECT Name, Version FROM Channel WHERE UserId = @UserId",
                    new { UserId = userId }
                );

                foreach (var channel in channels)
                {
                    var channelName = channel.Name.ToString();
                    var channelVersion = Convert.ToInt32(channel.Version);

                    var messages = await GetChannelMessagesFromDatabaseAsync(channelName, userId);

                    var channelInfo = new ChannelInfo
                    {
                        Name = channelName,
                        Version = channelVersion,
                        Messages = messages,
                        Members = new List<object> { new { Id = userId } }
                    };
                    channelInfoList.Add(channelInfo);
                }
            }

            return channelInfoList;
        }

        public class ChannelInfo
        {
            public string Name { get; set; }
            public int Version { get; set; }
            public List<object> Messages { get; set; }
            public List<object> Members { get; set; }
        }

        private async Task<List<object>> GetChannelMessagesFromDatabaseAsync(string channelName, int userId)
        {
            var messagesList = new List<object>();

            using (var connection = await GetOpenConnectionAsync())
            {
                var lastMessageIdShown = await GetLastMessageIdShownAsync(userId);

                var messages = await connection.QueryAsync<dynamic>(
                    "SELECT UniqueId, UserId, Text, Timestamp FROM ChannelMessage WHERE ChannelName = @ChannelName AND UniqueId > @LastMessageIdShown",
                    new { ChannelName = channelName, LastMessageIdShown = lastMessageIdShown }
                );

                foreach (var message in messages)
                {
                    var msg = new
                    {
                        Id = message.UniqueId,
                        From = new { Id = message.UserId },
                        Text = message.Text,
                        Timestamp = message.Timestamp
                    };
                    messagesList.Add(msg);
                }

                if (messages.Any())
                {
                    var latestMessageId = messages.Max(msg => msg.UniqueId);
                    await UpdateLastMessageIdShownAsync(userId, latestMessageId);
                }
            }

            return messagesList;
        }

        private async Task<string> GetLastMessageIdShownAsync(int userId)
        {
            using (var connection = await GetOpenConnectionAsync())
            {
                return await connection.ExecuteScalarAsync<string>(
                    "SELECT LastMessageIdShown FROM User WHERE Id = @UserId",
                    new { UserId = userId }
                );
            }
        }

        private async Task UpdateLastMessageIdShownAsync(int userId, string messageId)
        {
            using (var connection = await GetOpenConnectionAsync())
            {
                await connection.ExecuteAsync(
                    "UPDATE User SET LastMessageIdShown = @MessageId WHERE Id = @UserId",
                    new { UserId = userId, MessageId = messageId }
                );
            }
        }

        private async Task<SQLiteConnection> GetOpenConnectionAsync()
        {
            var connection = new SQLiteConnection(ConnectionString);
            await connection.OpenAsync();
            return connection;
        }

        [HttpPost]
        public async Task<SendResult> Send(SendRequest request)
        {
            int userId;
            this.TryGetUserId(out userId);

            bool sent = false;
            string uniqueId = Guid.NewGuid().ToString();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                await connection.OpenAsync();

                var userExists = await connection.ExecuteScalarAsync<int>(
                    "SELECT COUNT(*) FROM Channel WHERE UserId = @UserId", new { UserId = userId });

                if (userExists > 0)
                {
                    var channelExists = await connection.ExecuteScalarAsync<int>(
                        "SELECT COUNT(*) FROM Channel WHERE Name = @ChannelName", new { ChannelName = request.ChannelName });

                    if (channelExists > 0)
                    {
                        sent = true;

                        var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                        await connection.ExecuteAsync(
                            "INSERT INTO ChannelMessage (ChannelName, UserId, Text, Timestamp, UniqueId) VALUES (@ChannelName, @UserId, @Text, @Timestamp, @UniqueId)",
                            new { ChannelName = request.ChannelName, UserId = userId, Text = request.Message, Timestamp = timestamp, UniqueId = uniqueId });
                    }
                }
            }

            return new SendResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = sent
                }
            };
        }
    }
}
