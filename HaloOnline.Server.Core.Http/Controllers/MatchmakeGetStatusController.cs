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
                            var partyId = reader["Id"].ToString();

                            var members = GetPartyMembersFromDatabase(partyId);

                            return new MatchmakeStatus
                            {
                                Id = new MatchmakeId
                                {
                                    Id = partyId
                                },
                                Members = members,
                                MatchmakeTimer = 0
                            };
                        }
                        else
                        {
                            return new MatchmakeStatus();
                        }
                    }
                }
            }
        }

        private List<MatchmakeMember> GetPartyMembersFromDatabase(string partyId)
        {
            List<MatchmakeMember> members = new List<MatchmakeMember>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT UserId, IsOwner FROM PartyMember WHERE PartyId = @partyId", connection))
                {
                    command.Parameters.AddWithValue("@partyId", partyId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int userId = int.Parse(reader["UserId"].ToString());
                            bool isOwner = Convert.ToBoolean(reader["IsOwner"]);

                            members.Add(new MatchmakeMember
                            {
                                User = new UserId
                                {
                                    Id = userId
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

            return members;
        }

        private void UpdateMatchmakeStateInDatabase(int userId)
                    {
                        using (var connection = new SQLiteConnection(ConnectionString))
                        {
                            connection.Open();

                            using (var command = new SQLiteCommand("UPDATE Party SET MatchmakeState = 1", connection))
                            {
                                command.Parameters.AddWithValue("@userId", userId);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
