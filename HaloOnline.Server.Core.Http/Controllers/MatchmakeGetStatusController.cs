using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Presence;
using HaloOnline.Server.Core.Repository;
using HaloOnline.Server.Model.Presence;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("PresenceService.svc")]
    public class MatchmakeGetStatusController : ApiController
    {
        private HaloDbContext db = new HaloDbContext();

        [HttpPost]
        [Route("MatchmakeGetStatus")]
        [Authorize]
        public IHttpActionResult MatchmakeGetStatus(MatchmakeGetStatusRequest request)
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                if (userId == -1)
                {
                    return Unauthorized();
                }

                var matchmakeStatus = GetMatchmakeStatusFromDatabase();

                return Ok(new MatchmakeGetStatusResult
                {
                    Result = new ServiceResult<MatchmakeStatus>
                    {
                        Data = matchmakeStatus
                    }
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private MatchmakeStatus GetMatchmakeStatusFromDatabase()
        {
            var matchmakeStatus = new MatchmakeStatus
            {
                Id = new MatchmakeId
                {
                    Id = "d37e4cc7-eef4-4153-96b1-be515a8af3ce"
                },
                Members = new List<MatchmakeMember>(),
                MatchmakeTimer = 0,
            };

            var partyMembers = db.PartyMembers.ToList();

            foreach (var member in partyMembers)
            {
                if (PartyHasMatchmakeState(member.PartyId))
                {
                    matchmakeStatus.Members.Add(new MatchmakeMember
                    {
                        User = new UserId { Id = member.UserId },
                        Party = new PartyId { Id = member.PartyId },
                        IsOwner = member.IsOwner
                    });
                }
            }

            matchmakeStatus.Members.Sort((x, y) => x.User.Id.CompareTo(y.User.Id));

            return matchmakeStatus;
        }
        private bool PartyHasMatchmakeState(string partyId)
        {
            var party = db.Parties.FirstOrDefault(p => p.Id == partyId);
            return party != null && party.MatchmakeState > 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}