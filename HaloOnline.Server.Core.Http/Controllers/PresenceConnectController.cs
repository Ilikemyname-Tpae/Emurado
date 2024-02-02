using System;
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
    public class PresenceConnectController : ApiController
    {
        [HttpPost]
        [Route("PresenceConnect")]
        [Authorize]
        public IHttpActionResult PresenceConnect()
        {
            var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
            int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

            string partyId;
            int matchmakeState;
            string gameDataString;

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=halodb.sqlite;"))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand checkCommand = new SQLiteCommand(connection))
                    {
                        checkCommand.CommandText = "SELECT Id, MatchmakeState, GameData FROM Party";
                        checkCommand.Parameters.AddWithValue("@UserId", userId);

                        using (SQLiteDataReader reader = checkCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                partyId = reader["Id"].ToString();
                                matchmakeState = Convert.ToInt32(reader["MatchmakeState"]);
                                gameDataString = reader["GameData"].ToString();
                            }
                            else
                            {
                                partyId = Guid.NewGuid().ToString();
                                matchmakeState = 0;
                                gameDataString = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==";

                                using (SQLiteCommand insertCommand = new SQLiteCommand(connection))
                                {
                                    insertCommand.CommandText = "INSERT INTO Party (Id, MatchmakeState, GameData) VALUES (@Id, @MatchmakeState, @GameData)";
                                    insertCommand.Parameters.AddWithValue("@Id", partyId);
                                    insertCommand.Parameters.AddWithValue("@MatchmakeState", matchmakeState);
                                    insertCommand.Parameters.AddWithValue("@GameData", gameDataString);

                                    insertCommand.ExecuteNonQuery();
                                }

                                using (SQLiteCommand insertUserCommand = new SQLiteCommand(connection))
                                {
                                    insertUserCommand.CommandText = "INSERT INTO PartyMember (PartyId, UserId, IsOwner) VALUES (@PartyId, @UserId, @IsOwner)";
                                    insertUserCommand.Parameters.AddWithValue("@PartyId", partyId);
                                    insertUserCommand.Parameters.AddWithValue("@UserId", userId);
                                    insertUserCommand.Parameters.AddWithValue("@IsOwner", true);

                                    insertUserCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        if (!IsUserAlreadyInParty(connection, partyId, userId))
                        {
                            using (SQLiteCommand insertSessionMemberCommand = new SQLiteCommand(connection))
                            {
                                insertSessionMemberCommand.CommandText = "INSERT INTO PartyMember (PartyId, UserId, IsOwner) VALUES (@PartyId, @UserId, @IsOwner)";
                                insertSessionMemberCommand.Parameters.AddWithValue("@PartyId", partyId);
                                insertSessionMemberCommand.Parameters.AddWithValue("@UserId", userId);
                                insertSessionMemberCommand.Parameters.AddWithValue("@IsOwner", false);

                                insertSessionMemberCommand.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                }
            }

            var partyMembers = GetPartyMembers(partyId);

            return Ok(CreateResultObject(partyId, userId, matchmakeState, gameDataString, partyMembers));
        }

        private bool IsUserAlreadyInParty(SQLiteConnection connection, string partyId, int userId)
        {
            using (SQLiteCommand checkUserCommand = new SQLiteCommand(connection))
            {
                checkUserCommand.CommandText = "SELECT COUNT(*) FROM PartyMember WHERE PartyId = @PartyId AND UserId = @UserId";
                checkUserCommand.Parameters.AddWithValue("@PartyId", partyId);
                checkUserCommand.Parameters.AddWithValue("@UserId", userId);

                int count = Convert.ToInt32(checkUserCommand.ExecuteScalar());
                return count > 0;
            }
        }

        private object CreateResultObject(string partyId, int userId, int matchmakeState, string gameDataString, object[] partyMembers)
        {
            return new
            {
                PresenceConnectResult = new
                {
                    retCode = 0,
                    data = new
                    {
                        Party = new
                        {
                            Id = partyId,
                        },
                        SessionMembers = partyMembers,
                        MatchmakeState = matchmakeState,
                        GameData = ""
                    }
                }
            };
        }

        private object[] GetPartyMembers(string partyId)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=halodb.sqlite;"))
            {
                connection.Open();

                using (SQLiteCommand selectMembersCommand = new SQLiteCommand(connection))
                {
                    selectMembersCommand.CommandText = "SELECT UserId, IsOwner FROM PartyMember WHERE PartyId = @PartyId";
                    selectMembersCommand.Parameters.AddWithValue("@PartyId", partyId);

                    using (SQLiteDataReader reader = selectMembersCommand.ExecuteReader())
                    {
                        var partyMembers = new System.Collections.Generic.List<object>();

                        while (reader.Read())
                        {
                            int memberId = Convert.ToInt32(reader["UserId"]);
                            bool isOwner = Convert.ToBoolean(reader["IsOwner"]);

                            var member = new
                            {
                                User = new
                                {
                                    Id = memberId
                                },
                                IsOwner = isOwner
                            };

                            partyMembers.Add(member);
                        }

                        return partyMembers.ToArray();
                    }
                }
            }
        }
    }
}
