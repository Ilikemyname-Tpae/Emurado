using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Security.Claims;
using System.Threading;
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
        private static readonly object databaseLock = new object();
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("PartyJoin")]
        [Authorize]
        public PartyJoinResult PartyJoin(PartyJoinRequest request)
        {
            try
            {
                lock (databaseLock)
                {
                    var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                    int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                    var partyId = request?.Party?.Id;

                    if (partyId == null)
                    {
                        return new PartyJoinResult
                        {
                            Result = new ServiceResult<PartyStatus>
                            {
                            }
                        };
                    }

                    SavePartyIdToDatabase(userId, partyId);

                    var partyStatus = GetPartyStatusFromDatabase(userId, partyId);

                    RemoveChannelMessageForUser(userId);

                    foreach (var member in partyStatus.SessionMembers)
                    {
                        if (member.User.Id == userId)
                        {
                            member.IsOwner = false;
                            break;
                        }
                    }

                    return new PartyJoinResult
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
                return new PartyJoinResult
                {
                    Result = new ServiceResult<PartyStatus>
                    {
                    }
                };
            }
        }

        private void SavePartyIdToDatabase(int userId, string partyId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("UPDATE PartyMember SET PartyId = @partyId WHERE UserId = @userId", connection))
                {
                    command.Parameters.AddWithValue("@partyId", partyId);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private PartyStatus GetPartyStatusFromDatabase(int userId, string partyId)
        {
            var partyMembers = new List<PartyMemberDto>();
            bool isUserOwner = false;

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT UserId FROM PartyMember WHERE PartyId = @partyId", connection))
                {
                    command.Parameters.AddWithValue("@partyId", partyId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var memberId = Convert.ToInt32(reader["UserId"]);

                            bool isOwner = memberId == userId;
                            if (isOwner)
                                isUserOwner = true; 

                            partyMembers.Add(new PartyMemberDto
                            {
                                User = new UserId { Id = memberId },
                                IsOwner = isOwner
                            });
                        }
                    }
                }

                using (var command = new SQLiteCommand("SELECT Id, MatchmakeState, GameData FROM Party WHERE Id = @partyId", connection))
                {
                    command.Parameters.AddWithValue("@partyId", partyId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int matchmakeState = Convert.ToInt32(reader["MatchmakeState"]);
                            byte[] gameData = reader["GameData"] as byte[] ?? new byte[100];

                            return new PartyStatus
                            {
                                Party = new PartyId { Id = partyId },
                                SessionMembers = partyMembers,
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

        // shitty way of stopping the repetitive messages after joining, but it works regardless, i'll look into finding another way
        private void RemoveChannelMessageForUser(int userId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("DELETE FROM ChannelMessage WHERE ChannelName = @channelName", connection))
                {
                    command.Parameters.AddWithValue("@channelName", $"#private_{userId}");
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
