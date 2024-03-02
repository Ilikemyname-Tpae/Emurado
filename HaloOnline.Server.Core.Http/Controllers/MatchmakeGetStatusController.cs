using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Presence;
using HaloOnline.Server.Model.Presence;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("PresenceService.svc")]
    public class MatchmakeGetStatusController : ApiController
    {
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("MatchmakeGetStatus")]
        [Authorize]
        public MatchmakeGetStatusResult MatchmakeGetStatus(MatchmakeGetStatusRequest request)
        {
            var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
            int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

            var matchmakeStatus = GetMatchmakeStatusFromDatabase(userId);

            UpdateMatchmakeStateInDatabase(userId);

            return new MatchmakeGetStatusResult
            {
                Result = new ServiceResult<MatchmakeStatus>
                {
                    Data = matchmakeStatus
                }
            };
        }

        private MatchmakeStatus GetMatchmakeStatusFromDatabase(int userId)
        {
            var matchmakeStatus = new MatchmakeStatus
            {
                Id = new MatchmakeId
                {
                    Id = "7c6f4cf1-c80c-46ea-b724-51d6b892c5c1"
                },
                Members = new List<MatchmakeMember>(),
                MatchmakeTimer = 0,
            };

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT UserId, PartyId, IsOwner FROM PartyMember", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var memberId = reader.GetInt32(0);
                            var partyId = reader.GetString(1);
                            var isOwner = reader.GetBoolean(2);

                            if (PartyHasMatchmakeState(connection, partyId))
                            {
                                matchmakeStatus.Members.Add(new MatchmakeMember
                                {
                                    User = new UserId
                                    {
                                        Id = memberId
                                    },
                                    Party = new PartyId
                                    {
                                        Id = partyId
                                    },
                                    IsOwner = isOwner
                                });
                            }
                        }
                    }
                }
            }

            // just something to make it so it look like each userside looks like theyre first in the lobby
            matchmakeStatus.Members.Sort((x, y) => x.User.Id == userId ? -1 : y.User.Id == userId ? 1 : 0);

            return matchmakeStatus;
        }


        private bool PartyHasMatchmakeState(SQLiteConnection connection, string partyId)
        {
            using (var command = new SQLiteCommand("SELECT MatchmakeState FROM Party WHERE Id = @partyId", connection))
            {
                command.Parameters.AddWithValue("@partyId", partyId);
                var matchmakeState = command.ExecuteScalar();

                return matchmakeState != null && Convert.ToInt32(matchmakeState) == 1;
            }
        }

        private void UpdateMatchmakeStateInDatabase(int userId)
        {
            string partyId;
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT PartyId FROM PartyMember WHERE UserId = @userId", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    partyId = command.ExecuteScalar()?.ToString();
                }
            }

            if (partyId != null)
            {
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand("UPDATE Party SET MatchmakeState = 1 WHERE Id = @partyId", connection))
                    {
                        command.Parameters.AddWithValue("@partyId", partyId);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}