using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Model.Presence;
using HaloOnline.Server.Core.Repository;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("PresenceService.svc")]
    public class PartyGetStatusController : ApiController
    {

        [HttpPost]
        [Route("PartyGetStatus")]
        [Authorize]
        public IHttpActionResult PartyGetStatus()
        {
            var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
            int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

            var matchmakeState = MatchmakeService.GetMatchmakeState();

            var result = new
            {
                PartyGetStatusResult = new
                {
                    retCode = 0,
                    data = new
                    {
                        Party = new
                        {
                            Id = "d6525406-229f-4a6d-b243-3580ee7b6fe3"
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
                        MatchmakeState = matchmakeState,
                        GameData = "AAAAAHBsYXlsaXN0MQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=="
                    }
                }
            };

            return Ok(result);
        }
    }
}