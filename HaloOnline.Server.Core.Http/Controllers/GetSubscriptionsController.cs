using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Repository;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("FriendsService.svc")]
    public class GetSubscriptionsController : ApiController
    {
        private readonly HaloDbContext _dbContext = new HaloDbContext();

        [HttpPost]
        [Route("GetSubscriptions")]
        public IHttpActionResult GetSubscriptions()
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                var subscriptions = _dbContext.UserSubscriptions
                                               .Where(us => us.SubscriberId == userId)
                                               .Select(us => new { Id = us.SubscribeeId })
                                               .ToList();

                var result = new
                {
                    GetSubscriptionsResult = new
                    {
                        retCode = 0,
                        data = new List<object>
                        {
                            new
                            {
                                User = new
                                {
                                    Id = userId
                                },
                                Version = 0,
                                Subscriptions = new
                                {
                                    UserList = subscriptions
                                }
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
