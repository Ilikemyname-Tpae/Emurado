using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
    public class PartyJoinController : ApiController
    {
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("PartyJoin")]
        [Authorize]
        public PartyJoinResult PartyJoin(PartyJoinRequest request)
        {
            var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
            int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

            var partyStatus = GetPartyStatusFromDatabase(userId);

            return new PartyJoinResult
            {
                Result = new ServiceResult<PartyStatus>
                {
                    Data = partyStatus
                }
            };
        }

        private PartyStatus GetPartyStatusFromDatabase(int userId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT Id, MatchmakeState, GameData FROM Party", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string partyId = reader["Id"].ToString();
                            int matchmakeState = Convert.ToInt32(reader["MatchmakeState"]);
                            byte[] gameData = reader["GameData"] as byte[] ?? new byte[100];

                            return new PartyStatus
                            {
                                Party = new PartyId
                                {
                                    Id = partyId
                                },
                                SessionMembers = new List<PartyMemberDto>
                                {
                                    new PartyMemberDto
                                    {
                                        User = new UserId
                                        {
                                            Id = userId
                                        },
                                        IsOwner = true
                                    }
                                },
                                MatchmakeState = matchmakeState,
                                GameData = gameData
                            };
                        }
                        else
                        {
                            return new PartyStatus();
                        }
                    }
                }
            }
        }
    }
}
