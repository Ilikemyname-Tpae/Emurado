using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("MessagingService.svc")]
    public class ReceiveController : ApiController
    {
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;Pooling=True;Max Pool Size=100;";
        private static readonly object databaseLock = new object();


        [HttpPost]
        [Route("Receive")]
        public async Task<IHttpActionResult> Receive()
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                await Task.Run(() => UpdateUserColumns(userId));

                var channelInfoList = await Task.Run(() => GetChannelInfoFromDatabase(userId));

                var result = new
                {
                    ReceiveResult = new
                    {
                        retCode = 0,
                        data = channelInfoList
                    }
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private async Task UpdateUserColumns(int userId)
        {
            using (var connection = await GetOpenConnectionAsync())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE User SET State = 1, IsInvitable = 1 WHERE Id = @UserId";
                command.Parameters.AddWithValue("@UserId", userId);
                await command.ExecuteNonQueryAsync();
            }
        }

        private async Task<List<object>> GetChannelInfoFromDatabase(int userId)
        {
            var channelInfoList = new List<object>();

            using (var connection = await GetOpenConnectionAsync())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Name, Version FROM Channel WHERE UserId = @UserId";
                command.Parameters.AddWithValue("@UserId", userId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var channelName = reader["Name"].ToString();
                        var channelVersion = Convert.ToInt32(reader["Version"]);

                        var messages = await GetChannelMessagesFromDatabase(channelName, userId);

                        var channelInfo = new
                        {
                            Name = channelName,
                            Version = channelVersion,
                            Messages = messages,
                            Members = new[]
                            {
                            new { Id = userId }
                        }
                        };
                        channelInfoList.Add(channelInfo);
                    }
                }
            }

            return channelInfoList;
        }

        private async Task<List<object>> GetChannelMessagesFromDatabase(string channelName, int userId)
        {
            var messagesList = new List<object>();

            using (var connection = await GetOpenConnectionAsync())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT UserId, Text, Timestamp FROM ChannelMessage WHERE ChannelName = @ChannelName";
                command.Parameters.AddWithValue("@ChannelName", channelName);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var message = new
                        {
                            From = new { Id = Convert.ToInt32(reader["UserId"]) },
                            Text = reader["Text"].ToString(),
                            Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds()
                        };
                        messagesList.Add(message);
                    }
                }
            }

            return messagesList;
        }

        private async Task<SQLiteConnection> GetOpenConnectionAsync()
        {
            var connection = new SQLiteConnection(ConnectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}