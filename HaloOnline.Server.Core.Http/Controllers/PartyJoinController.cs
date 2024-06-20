using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Presence;
using HaloOnline.Server.Core.Repository;
using HaloOnline.Server.Model.Presence;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("PresenceService.svc")]
    public class PartyJoinController : ApiController
    {
        private readonly HaloDbContext _dbContext = new HaloDbContext();

        [HttpPost]
        [Route("PartyJoin")]
        [Authorize]
        public IHttpActionResult PartyJoin(PartyJoinRequest request)
        {
            try
            {
                var userId = GetCurrentUserId();
                var partyId = request?.Party?.Id;

                if (partyId == null)
                {
                    return BadRequest("Invalid party ID.");
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

                return Ok(new PartyJoinResult
                {
                    Result = new ServiceResult<PartyStatus>
                    {
                        Data = partyStatus
                    }
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;
        }

        private void SavePartyIdToDatabase(int userId, string partyId)
        {
            var partyMember = _dbContext.PartyMembers.FirstOrDefault(pm => pm.UserId == userId);

            if (partyMember != null)
            {
                partyMember.PartyId = partyId;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("User is not a member of any party.");
            }
        }

        private PartyStatus GetPartyStatusFromDatabase(int userId, string partyId)
        {
            var partyMembers = _dbContext.PartyMembers
                                        .Where(pm => pm.PartyId == partyId)
                                        .Select(pm => new PartyMemberDto
                                        {
                                            User = new UserId { Id = pm.UserId },
                                            IsOwner = pm.UserId == userId
                                        })
                                        .ToList();

            var party = _dbContext.Parties.FirstOrDefault(p => p.Id == partyId);

            if (party != null)
            {
                return new PartyStatus
                {
                    Party = new PartyId { Id = party.Id },
                    SessionMembers = partyMembers,
                    MatchmakeState = party.MatchmakeState,
                    GameData = party.GameData
                };
            }
            else
            {
                return new PartyStatus();
            }
        }

        private void RemoveChannelMessageForUser(int userId)
        {
            var channelName = $"#private_{userId}";
            var channelMessage = _dbContext.ChannelMessages.FirstOrDefault(cm => cm.ChannelName == channelName);

            if (channelMessage != null)
            {
                _dbContext.ChannelMessages.Remove(channelMessage);
                _dbContext.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
