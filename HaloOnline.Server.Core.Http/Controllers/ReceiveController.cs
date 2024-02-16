using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("MessagingService.svc")]
    public class ReceiveController : ApiController
    {
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("Receive")]
        public IHttpActionResult Receive()
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                var channelInfoList = GetChannelInfoFromDatabase(userId);

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

        private List<object> GetChannelInfoFromDatabase(int userId)
        {
            var channelInfoList = new List<object>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT Name, Version FROM Channel WHERE UserId = @UserId";
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var channelName = reader["Name"].ToString();
                            var channelVersion = Convert.ToInt32(reader["Version"]);

                            var messages = GetChannelMessagesFromDatabase(channelName, userId);

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
            }

            return channelInfoList;
        }

        private List<object> GetChannelMessagesFromDatabase(string channelName, int userId)
        {
            var messagesList = new List<object>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT UserId, Text, Timestamp FROM ChannelMessage WHERE ChannelName = @ChannelName";
                    command.Parameters.AddWithValue("@ChannelName", channelName);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var message = new
                            {
                                From = new { Id = Convert.ToInt32(reader["UserId"]) },
                                Text = reader["Text"].ToString(),
                                Timestamp = 1708074088
                            };
                            messagesList.Add(message);
                        }
                    }
                }
            }

            return messagesList;
        }
    }
}
