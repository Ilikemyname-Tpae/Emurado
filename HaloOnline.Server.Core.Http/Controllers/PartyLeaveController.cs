using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Presence;
using HaloOnline.Server.Model.Presence;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("PresenceService.svc")]
    public class PartyLeaveController : ApiController
    {
        private static readonly string ConnectionString = "Data Source=halodb.sqlite;Version=3;";
        private static SQLiteConnection _connection;
        private static readonly object databaseLock = new object();

        public PartyLeaveController()
        {
            _connection = new SQLiteConnection(ConnectionString);
            _connection.Open();
        }

        [HttpPost]
        [Route("PartyLeave")]
        [Authorize]
        public PartyLeaveResult PartyLeave(PartyLeaveRequest request)
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                var newPartyId = Guid.NewGuid().ToString();

                lock (databaseLock)
                {
                    var partyStatus = UpdatePartyMemberAndGetStatus(userId, newPartyId);

                    return new PartyLeaveResult
                    {
                        Result = new ServiceResult<PartyStatus>
                        {
                            Data = partyStatus
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                return new PartyLeaveResult
                {
                    Result = new ServiceResult<PartyStatus>
                    {
                    }
                };
            }
        }

            private PartyStatus UpdatePartyMemberAndGetStatus(int userId, string newPartyId)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    string currentPartyId;
                    using (var checkCurrentPartyCommand = new SQLiteCommand("SELECT PartyId FROM PartyMember WHERE UserId = @userId", _connection, transaction))
                    {
                        checkCurrentPartyCommand.Parameters.AddWithValue("@userId", userId);
                        currentPartyId = checkCurrentPartyCommand.ExecuteScalar()?.ToString();
                    }

                    if (!string.IsNullOrEmpty(currentPartyId))
                    {
                        using (var removeUserCommand = new SQLiteCommand("DELETE FROM PartyMember WHERE UserId = @userId", _connection, transaction))
                        {
                            removeUserCommand.Parameters.AddWithValue("@userId", userId);
                            removeUserCommand.ExecuteNonQuery();
                        }

                        using (var checkRemainingMembersCommand = new SQLiteCommand("SELECT COUNT(*) FROM PartyMember WHERE PartyId = @currentPartyId", _connection, transaction))
                        {
                            checkRemainingMembersCommand.Parameters.AddWithValue("@currentPartyId", currentPartyId);
                            int remainingMembers = Convert.ToInt32(checkRemainingMembersCommand.ExecuteScalar());

                            if (remainingMembers == 0)
                            {
                                using (var removePartyCommand = new SQLiteCommand("DELETE FROM Party WHERE Id = @currentPartyId", _connection, transaction))
                                {
                                    removePartyCommand.Parameters.AddWithValue("@currentPartyId", currentPartyId);
                                    removePartyCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    using (var createPartyCommand = new SQLiteCommand("INSERT OR IGNORE INTO Party (Id, MatchmakeState, GameData) VALUES (@newPartyId, @matchmakeState, @gameData)", _connection, transaction))
                    {
                        createPartyCommand.Parameters.AddWithValue("@newPartyId", newPartyId);
                        createPartyCommand.Parameters.AddWithValue("@matchmakeState", 0);
                        createPartyCommand.Parameters.AddWithValue("@gameData", "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==");
                        createPartyCommand.ExecuteNonQuery();
                    }

                    using (var addPartyMemberCommand = new SQLiteCommand("INSERT INTO PartyMember (PartyId, UserId, IsOwner) VALUES (@newPartyId, @userId, @isOwner)", _connection, transaction))
                    {
                        addPartyMemberCommand.Parameters.AddWithValue("@newPartyId", newPartyId);
                        addPartyMemberCommand.Parameters.AddWithValue("@userId", userId);
                        addPartyMemberCommand.Parameters.AddWithValue("@isOwner", true);
                        addPartyMemberCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    var partyStatus = new PartyStatus
                    {
                        Party = new PartyId { Id = newPartyId },
                        SessionMembers = new List<PartyMemberDto>
                        {
                            new PartyMemberDto
                            {
                                User = new UserId { Id = userId },
                                IsOwner = true
                            }
                        },
                        MatchmakeState = 0,
                        GameData = new byte[100]
                    };

                    return partyStatus;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _connection?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
