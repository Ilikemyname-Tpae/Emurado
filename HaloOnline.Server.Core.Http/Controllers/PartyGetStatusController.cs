using System;
using System.Data.SQLite;
using System.Security.Claims;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Model.Presence;
using HaloOnline.Server.Model.Presence;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("PresenceService.svc")]
    public class PartyGetStatusController : ApiController
    {
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("PartyGetStatus")]
        [Authorize]
        public IHttpActionResult PartyGetStatus()
        {
            var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
            int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

            var partyStatus = GetPartyStatusFromDatabase(userId);

            var result = new
            {
                PartyGetStatusResult = new
                {
                    retCode = 0,
                    data = new
                    {
                        Party = new
                        {
                            Id = partyStatus.Party?.Id ?? "",
                        },
                        SessionMembers = new[]
                        {
                            new
                            {
                                User = new
                                {
                                    Id = userId
                                },
                                IsOwner = true
                            }
                        },
                        MatchmakeState = partyStatus.MatchmakeState,
                        GameData = partyStatus.GameData
                    }
                }
            };

            return Ok(result);
        }

        private PartyStatus GetPartyStatusFromDatabase(int userId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT PartyId FROM PartyMember WHERE UserId = @userId", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var partyId = reader["PartyId"].ToString();
                            return new PartyStatus
                            {
                                Party = new PartyId
                                {
                                    Id = partyId
                                },
                                MatchmakeState = GetMatchmakeStateForParty(partyId, connection),
                                GameData = GetGameDataForParty(partyId, connection)
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

        private int GetMatchmakeStateForParty(string partyId, SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand("SELECT MatchmakeState FROM Party WHERE Id = @partyId", connection))
            {
                command.Parameters.AddWithValue("@partyId", partyId);
                var result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private byte[] GetGameDataForParty(string partyId, SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand("SELECT GameData FROM Party WHERE Id = @partyId", connection))
            {
                command.Parameters.AddWithValue("@partyId", partyId);
                var result = command.ExecuteScalar();
                return result as byte[] ?? new byte[100];
            }
        }
    }
}