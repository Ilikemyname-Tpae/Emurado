using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("MessagingService.svc")]
    public class JoinChannelsController : ApiController
    {
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("JoinChannels")]
        [Authorize]
        public IHttpActionResult JoinChannels()
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                var requestBody = Request.Content.ReadAsStringAsync().Result;
                dynamic requestData = JsonConvert.DeserializeObject(requestBody);
                var channelNames = requestData?.channelNames?.ToObject<List<string>>();

                var channelInfoList = new List<object>();

                if (channelNames != null)
                {
                    foreach (var channelName in channelNames)
                    {
                        AddChannelToDatabase(channelName, userId);
                        var channelInfo = GetChannelInfo(channelName, userId);
                        if (channelInfo != null)
                            channelInfoList.Add(channelInfo);
                    }
                }

                var result = new
                {
                    JoinChannelsResult = new
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

        private void AddChannelToDatabase(string channelName, int userId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO Channel (Name, Version, UserId) VALUES (@Name, @Version, @UserId)";
                    command.Parameters.AddWithValue("@Name", channelName);
                    command.Parameters.AddWithValue("@Version", 1); // i reckon it wont change at all tbf
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private object GetChannelInfo(string channelName, int userId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT Id, Name, Version FROM Channel WHERE Name = @Name AND UserId = @UserId";
                    command.Parameters.AddWithValue("@Name", channelName);
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new
                            {
                                Name = reader["Name"].ToString(),
                                Version = Convert.ToInt32(reader["Version"]),
                                Messages = new List<object>(),
                                Members = new[]
                                {
                                    new { Id = userId }
                                }
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
