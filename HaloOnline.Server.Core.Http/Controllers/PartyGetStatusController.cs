using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Model.User;
using HaloOnline.Server.Core.Repository;
using HaloOnline.Server.Model.Presence;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("PresenceService.svc")]
    public class PartyGetStatusController : ApiController
    {
        private readonly HaloDbContext _context;

        public PartyGetStatusController()
        {
            _context = new HaloDbContext();
        }

        [HttpPost]
        [Route("PartyGetStatus")]
        [Authorize]
        public async Task<IHttpActionResult> PartyGetStatus()
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                PartyStatus partyStatus = await GetPartyStatusFromDatabaseAsync(userId);

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
                            SessionMembers = partyStatus.SessionMembers,
                            MatchmakeState = partyStatus.MatchmakeState,
                            GameData = partyStatus.GameData
                        }
                    }
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private async Task<PartyStatus> GetPartyStatusFromDatabaseAsync(int userId)
        {
            var partyMember = await _context.PartyMembers
                                             .Include(pm => pm.Party)
                                             .FirstOrDefaultAsync(pm => pm.UserId == userId);

            if (partyMember != null)
            {
                var party = partyMember.Party;
                var sessionMembers = await GetSessionMembersForPartyAsync(party.Id);

                return new PartyStatus
                {
                    Party = new PartyId { Id = party.Id },
                    SessionMembers = sessionMembers,
                    MatchmakeState = party.MatchmakeState,
                    GameData = party.GameData ?? new byte[100]
                };
            }
            else
            {
                return new PartyStatus();
            }
        }

        private async Task<List<PartyMemberDto>> GetSessionMembersForPartyAsync(string partyId)
        {
            var sessionMembers = await _context.PartyMembers
                                               .Where(pm => pm.PartyId == partyId)
                                               .Select(pm => new PartyMemberDto
                                               {
                                                   Id = pm.UserId,
                                                   IsOwner = pm.IsOwner,
                                                   User = new UserDto { Id = pm.UserId }
                                               })
                                               .ToListAsync();

            return sessionMembers;
        }
    }
}
