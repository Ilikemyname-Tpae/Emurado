using System.Collections.Generic;
using System.Data.SQLite;
using System.Web.Http;
using System;
using System.Security.Claims;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("FriendsService.svc")]
    public class GetSubscriptionsController : ApiController
    {
        private readonly string _connectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("GetSubscriptions")]
        public IHttpActionResult GetSubscriptions()
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                var subscriptions = new List<object>();

                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT SubscribeeId FROM UserSubscription WHERE SubscriberId = @userId";
                        command.Parameters.AddWithValue("@userId", userId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int subscribeeId = reader.GetInt32(0);
                                subscriptions.Add(new { Id = subscribeeId });
                            }
                        }
                    }
                }

                var result = new
                {
                    GetSubscriptionsResult = new
                    {
                        retCode = 0,
                        data = new List<object>
                        {
                            new
                            {
                                User = new
                                {
                                    Id = userId
                                },
                                Version = 0,
                                Subscriptions = new
                                {
                                    UserList = subscriptions
                                }
                            }
                        }
                    }
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}