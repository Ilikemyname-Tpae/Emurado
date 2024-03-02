using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Security.Claims;
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
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("PartyLeave")]
        [Authorize]
        public PartyLeaveResult PartyLeave(PartyLeaveRequest request)
        {
            var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
            int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

            var newPartyId = Guid.NewGuid().ToString();

            UpdatePartyMember(userId, newPartyId);
            // still need to make it so it updates the `Party` table.
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

            return new PartyLeaveResult
            {
                Result = new ServiceResult<PartyStatus>
                {
                    Data = partyStatus
                }
            };
        }

        private void UpdatePartyMember(int userId, string newPartyId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("UPDATE PartyMember SET PartyId = @newPartyId WHERE UserId = @userId", connection))
                {
                    command.Parameters.AddWithValue("@newPartyId", newPartyId);
                    command.Parameters.AddWithValue("@userId", userId);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}