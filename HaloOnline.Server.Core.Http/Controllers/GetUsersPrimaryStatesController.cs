using System.Web.Http;
using System.Security.Claims;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class GetUsersPrimaryStatesController : ApiController
    {
        [HttpPost]
        [Route("GetUsersPrimaryStates")]
        [Authorize]
        public IHttpActionResult GetUsersPrimaryStates()
        {
            var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
            int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

            var result = new
            {
                GetUsersPrimaryStatesResult = new
                {
                    retCode = 0,
                    data = new[]
                    {
                        new
                        {
                            User = new
                            {
                                Id = userId
                            },
                            Xp = 0,
                            Kills = 0,
                            Deaths = 0,
                            Assists = 0,
                            Suicides = 0,
                            TotalMatches = 0,
                            Victories = 0,
                            Defeats = 0,
                            TotalWP = 0,
                            TotalTimePlayed = 0,
                            TotalTimeOnline = 0
                        }
                    }
                }
            };

            return Ok(result);
        }
    }
}
