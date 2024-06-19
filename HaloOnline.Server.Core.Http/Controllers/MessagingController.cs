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
using System.Data.Entity;
using HaloOnline.Server.Core.Repository.Model;
using HaloOnline.Server.Core.Repository;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [Authorize]
    public class MessagingController : ApiController
    {
        private readonly HaloDbContext dbContext = new HaloDbContext();
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        public async Task<IHttpActionResult> LeaveChannels([FromBody] LeaveChannelsRequest request)
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                await UpdateUserColumnsAsync(userId);

                var channels = await GetChannelInfoFromDatabaseAsync();

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

        private async Task<List<ChannelInfo>> GetChannelInfoFromDatabaseAsync()
        {
            var channelInfoList = new List<ChannelInfo>();

            using (var connection = await GetOpenConnectionAsync())
            {
                var channels = await connection.QueryAsync<dynamic>(
                    "SELECT c.Name, c.Version, cu.UserId " +
                    "FROM Channel c " +
                    "JOIN ChannelUser cu ON UserId = cu.UserId"
                );

                foreach (var channel in channels)
                {
                    var channelName = channel.Name.ToString();
                    var channelVersion = Convert.ToInt32(channel.Version);
                    var userId = Convert.ToInt32(channel.UserId);

                    var messages = await GetChannelMessagesFromDatabaseAsync(channelName);

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

        private async Task<List<object>> GetChannelMessagesFromDatabaseAsync(string channelName)
        {
            var messagesList = new List<object>();

            using (var connection = await GetOpenConnectionAsync())
            {
                var messages = await connection.QueryAsync<dynamic>(
                    "SELECT Id, ChannelId, UserId, Text, Timestamp, Version, ChannelName FROM ChannelMessage WHERE ChannelName = @ChannelName",
                    new { ChannelName = channelName }
                );

                foreach (var message in messages)
                {
                    var msg = new
                    {
                        Id = message.Id,
                        ChannelId = message.ChannelId,
                        UserId = message.UserId,
                        Text = message.Text,
                        Timestamp = message.Timestamp,
                        Version = message.Version,
                        ChannelName = message.ChannelName
                    };
                    messagesList.Add(msg);
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

            try
            {
                var userExistsInChannel = await dbContext.ChannelsUsers
                    .AnyAsync(cu => cu.UserId == userId && cu.Channel.Name == request.ChannelName);

                if (userExistsInChannel)
                {
                    var channelExists = await dbContext.Channels
                        .AnyAsync(c => c.Name == request.ChannelName);

                    if (channelExists)
                    {
                        sent = true;

                        var timestamp = DateTime.UtcNow;
                        var message = new ChannelMessage
                        {
                            ChannelId = dbContext.Channels.First(c => c.Name == request.ChannelName).Id,
                            UserId = userId,
                            Text = request.Message,
                            Timestamp = timestamp,
                            Version = 1 
                        };

                        dbContext.ChannelMessages.Add(message);
                        await dbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return new SendResult
                {
                    Result = new ServiceResult<bool>
                    {
                        Data = false
                    }
                };
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