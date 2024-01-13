using System.Web.Http;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("TitleResourceService.svc")]
    public class GetTitleTagsPatchConfigurationController : ApiController
    {
        [HttpPost]
        [Route("GetTitleTagsPatchConfiguration")]
        // Will have to later check out how this works, but at the moment it's not important.

        public IHttpActionResult GetTitleTagsPatchConfiguration()
        {
            var response = new
            {
                GetTitleTagsPatchConfigurationResult = new
                {
                    retCode = 0,
                    data = new
                    {
                        CombinationHash = "",
                        Tags = new[] {
                        new {
                           Name = "",
                              Type = 0,
                              StrVal = "",
                              IntVal = 0,
                              FloatVal = 0.0
                        }
                     }
                    }
                }
            };

            return Ok(response);
        }
    }
}