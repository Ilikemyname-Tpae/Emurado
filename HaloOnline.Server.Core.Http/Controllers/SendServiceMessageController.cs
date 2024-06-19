using System;
using System.Data.SQLite;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Model.Messaging;
using HaloOnline.Server.Model.Messaging;
using System.Text;
using System.Security.Claims;
using HaloOnline.Server.Core.Http.Model;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("MessagingService.svc")]
    public class SendServiceMessageController : ApiController
    {
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("SendServiceMessage")]
        public SendServiceMessageResult SendServiceMessage(SendServiceMessageRequest request)
        {
            try
            {
                int userId;
                if (!TryGetUserId(out userId))
                {
                    return new SendServiceMessageResult
                    {
                        Result = new ServiceResult<bool>
                        {
                            ReturnCode = -1,
                        }
                    };
                }

                long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                int channelId;
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT Id FROM Channel WHERE Name = @ChannelName";
                        command.Parameters.AddWithValue("@ChannelName", request.ChannelName);
                        var result = command.ExecuteScalar();
                        if (result == null)
                        {
                            return new SendServiceMessageResult
                            {
                                Result = new ServiceResult<bool>
                                {
                                    ReturnCode = -1,
                                    Message = "Channel not found."
                                }
                            };
                        }
                        channelId = Convert.ToInt32(result);
                    }

                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "INSERT INTO ChannelMessage (ChannelId, UserId, Text, Timestamp) VALUES (@ChannelId, @UserId, @Text, @Timestamp)";
                        command.Parameters.AddWithValue("@ChannelId", channelId);
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@Text", request.Message);
                        command.Parameters.AddWithValue("@Timestamp", timestamp);
                        command.ExecuteNonQuery();
                    }
                }

                return new SendServiceMessageResult
                {
                    Result = new ServiceResult<bool>
                    {
                        ReturnCode = 0,
                        Data = true
                    }
                };
            }
            catch (Exception)
            {
                return new SendServiceMessageResult
                {
                    Result = new ServiceResult<bool>
                    {
                        ReturnCode = -1,
                    }
                };
            }
        }

        private bool TryGetUserId(out int userId)
        {
            var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out userId))
            {
                return true;
            }
            userId = -1;
            return false;
        }
    }
}