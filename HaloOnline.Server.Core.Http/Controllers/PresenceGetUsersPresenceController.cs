using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Presence;
using HaloOnline.Server.Model.Presence;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("PresenceService.svc")]
    public class PresenceGetUsersPresenceController : ApiController
    {
        private static List<int> activeUserIds = new List<int>();
        private static int initialUserState = 0;

        [HttpPost]
        [Route("PresenceGetUsersPresence")]
        public IHttpActionResult GetUserPresence()
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                if (!activeUserIds.Contains(userId))
                {
                    activeUserIds.Add(userId);
                }

                var userPresenceList = activeUserIds.Select(activeUserId => new UserPresence
                {
                    User = new UserId
                    {
                        Id = activeUserId
                    },
                    Data = new UserPresenceData
                    {
                        State = initialUserState,
                        IsInvitable = true
                    }
                }).ToList();

                initialUserState = 1;

                var response = new PresenceGetUsersPresenceResult
                {
                    Result = new ServiceResult<List<UserPresence>>
                    {
                        Data = userPresenceList
                    }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
