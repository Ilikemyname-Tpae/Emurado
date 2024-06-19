using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Dapper;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Presence;
using HaloOnline.Server.Model.Presence;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("PresenceService.svc")]
    public class PresenceGetUsersPresenceController : ApiController
    {
        private static readonly object databaseLock = new object();
        private static HashSet<int> activeUserIds = new HashSet<int>();

        private readonly string connectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("PresenceGetUsersPresence")]
        public async Task<IHttpActionResult> GetUserPresence(PresenceGetUsersPresenceRequest request)
        {
            try
            {
                if (request?.Users != null && request.Users.Any())
                {
                    int userId = request.Users[0].Id;

                    lock (databaseLock)
                    {
                        if (!activeUserIds.Contains(userId))
                        {
                            activeUserIds.Add(userId);
                        }
                    }

                    var userPresence = await GetUserPresenceAsync(userId);

                    if (userPresence != null)
                    {
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

                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private async Task<UserPresence> GetUserPresenceAsync(int userId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                bool isActive = activeUserIds.Contains(userId);

                string updateQuery = "UPDATE User SET State = @State WHERE Id = @Id";
                await connection.ExecuteAsync(updateQuery, new { State = isActive ? 1 : 0, Id = userId });

                string query = "SELECT State, IsInvitable FROM User WHERE Id = @Id";
                using (var multi = await connection.QueryMultipleAsync(query, new { Id = userId }))
                {
                    var userPresenceData = await multi.ReadSingleOrDefaultAsync<UserPresenceData>();

                    if (userPresenceData != null)
                    {
                        return new UserPresence
                        {
                            User = new UserId { Id = userId },
                            Data = userPresenceData
                        };
                    }
                }
            }

            return null;
        }
    }
}