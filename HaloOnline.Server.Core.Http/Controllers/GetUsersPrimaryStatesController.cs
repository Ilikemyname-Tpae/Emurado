using Newtonsoft.Json;
using System;
using System.Security.Claims;
using System.Web.Http;

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
            try
            {
                var requestBody = Request.Content.ReadAsStringAsync().Result;

                dynamic requestData = JsonConvert.DeserializeObject(requestBody);
                int userId = requestData?.users?[0]?.Id ?? -1;

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
                                Xp = 300,
                                Kills = 4,
                                Deaths = 0,
                                Assists = 2,
                                Suicides = 0,
                                TotalMatches = 1,
                                Victories = 1,
                                Defeats = 0,
                                TotalWP = 1,
                                TotalTimePlayed = 0,
                                TotalTimeOnline = 0
                            }
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
    }
}