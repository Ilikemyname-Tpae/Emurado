using Newtonsoft.Json;
using System;
using System.Data.SQLite;
using System.Security.Claims;
using System.Web.Http;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class GetUsersPrimaryStatesController : ApiController
    {
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("GetUsersPrimaryStates")]
        [Authorize]
        // Will eventually remake this so it uses Entity to avoid database locks
        public IHttpActionResult GetUsersPrimaryStates()
        {
            try
            {
                var requestBody = Request.Content.ReadAsStringAsync().Result;
                dynamic requestData = JsonConvert.DeserializeObject(requestBody);
                int userId = requestData?.users?[0]?.Id ?? -1;

                if (userId == -1)
                {
                    return BadRequest("Invalid user ID.");
                }

                var userData = GetOrCreateUserPrimaryState(userId);

                var result = new
                {
                    GetUsersPrimaryStatesResult = new
                    {
                        retCode = 0,
                        data = new[]
                        {
                            new
                            {
                                User = new
                                {
                                    Id = userData.UserId
                                },
                                userData.Xp,
                                userData.Kills,
                                userData.Deaths,
                                userData.Assists,
                                userData.Suicides,
                                userData.TotalMatches,
                                userData.Victories,
                                Defeats = userData.TotalMatches - userData.Victories,
                                userData.TotalWP,
                                userData.TotalTimePlayed,
                                userData.TotalTimeOnline
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

        private dynamic GetOrCreateUserPrimaryState(int userId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM UserPrimaryState WHERE UserId = @UserId";
                using (var selectCommand = new SQLiteCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new
                            {
                                UserId = reader.GetInt32(0),
                                Xp = reader.GetInt32(1),
                                Kills = reader.GetInt32(2),
                                Deaths = reader.GetInt32(3),
                                Assists = reader.GetInt32(4),
                                Suicides = reader.GetInt32(5),
                                TotalMatches = reader.GetInt32(6),
                                Victories = reader.GetInt32(7),
                                TotalWP = reader.GetInt32(8),
                                TotalTimePlayed = reader.GetInt32(9),
                                TotalTimeOnline = reader.GetInt32(10)
                            };
                        }
                    }
                }

                string insertQuery = @"INSERT INTO UserPrimaryState (UserId, Xp, Kills, Deaths, Assists, Suicides, TotalMatches, Victories, TotalWP, TotalTimePlayed, TotalTimeOnline)
                                       VALUES (@UserId, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)";
                using (var insertCommand = new SQLiteCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@UserId", userId);
                    insertCommand.ExecuteNonQuery();
                }

                return new
                {
                    UserId = userId,
                    Xp = 0,
                    Kills = 0,
                    Deaths = 0,
                    Assists = 0,
                    Suicides = 0,
                    TotalMatches = 0,
                    Victories = 0,
                    TotalWP = 0,
                    TotalTimePlayed = 0,
                    TotalTimeOnline = 0
                };
            }
        }
    }
}
