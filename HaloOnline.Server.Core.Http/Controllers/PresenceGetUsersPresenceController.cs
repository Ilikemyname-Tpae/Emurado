using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Presence;
using HaloOnline.Server.Model.Presence;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("PresenceService.svc")]
    public class PresenceGetUsersPresenceController : ApiController
    {
        private static List<int> activeUserIds = new List<int>();

        [HttpPost]
        [Route("PresenceGetUsersPresence")]
        public IHttpActionResult GetUserPresence(PresenceGetUsersPresenceRequest request)
        {
            try
            {
                if (request?.Users != null && request.Users.Any())
                {
                    int userId = request.Users[0].Id;

                    if (!activeUserIds.Contains(userId))
                    {
                        activeUserIds.Add(userId);
                    }

                    string connectionString = "Data Source=halodb.sqlite;Version=3;";
                    using (var connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT State, IsInvitable FROM User WHERE Id = @Id";
                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", userId);
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int state = Convert.ToInt32(reader["State"]);
                                    bool isInvitable = Convert.ToInt32(reader["IsInvitable"]) == 1;

                                    var userPresence = new UserPresence
                                    {
                                        User = new UserId { Id = userId },
                                        Data = new UserPresenceData
                                        {
                                            State = state,
                                            IsInvitable = isInvitable
                                        }
                                    };

                                    var response = new PresenceGetUsersPresenceResult
                                    {
                                        Result = new ServiceResult<List<UserPresence>>
                                        {
                                            Data = new List<UserPresence> { userPresence }
                                        }
                                    };

                                    return Ok(response);
                                }
                            }
                        }
                    }
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
