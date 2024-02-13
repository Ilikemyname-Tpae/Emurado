using System;
using System.Data.SQLite;
using System.Security.Claims;
using System.Web.Http;


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
                    partyId = Guid.NewGuid().ToString();
                    matchmakeState = 0;
                    gameDataString = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==";

                    using (SQLiteCommand insertPartyMemberCommand = new SQLiteCommand(connection))
                    {
                        insertPartyMemberCommand.CommandText = "INSERT INTO PartyMember (PartyId, UserId, IsOwner) VALUES (@PartyId, @UserId, @IsOwner)";
                        insertPartyMemberCommand.Parameters.AddWithValue("@PartyId", partyId);
                        insertPartyMemberCommand.Parameters.AddWithValue("@UserId", userId);
                        insertPartyMemberCommand.Parameters.AddWithValue("@IsOwner", true);

                        insertPartyMemberCommand.ExecuteNonQuery();
                    }

                    using (SQLiteCommand insertPartyCommand = new SQLiteCommand(connection))
                    {
                        insertPartyCommand.CommandText = "INSERT INTO Party (Id, MatchmakeState, GameData) VALUES (@Id, @MatchmakeState, @GameData)";
                        insertPartyCommand.Parameters.AddWithValue("@Id", partyId);
                        insertPartyCommand.Parameters.AddWithValue("@MatchmakeState", matchmakeState);
                        insertPartyCommand.Parameters.AddWithValue("@GameData", gameDataString);

                        insertPartyCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
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
                        GameData = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=="
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
