using System;
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
    public class MatchmakeStopController : ApiController
    {
        [HttpPost]
        [Route("MatchmakeStop")]
        [Authorize]
        public IHttpActionResult MatchmakeStop(MatchmakeStopRequest request)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=halodb.sqlite;"))
            {
                connection.Open();

                using (SQLiteCommand updateCommand = new SQLiteCommand(connection))
                {
                    updateCommand.CommandText = "UPDATE Party SET MatchmakeState = 0";

                    updateCommand.ExecuteNonQuery();
                }
            }

            return Ok(new MatchmakeStopResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            });
        }
    }
}
