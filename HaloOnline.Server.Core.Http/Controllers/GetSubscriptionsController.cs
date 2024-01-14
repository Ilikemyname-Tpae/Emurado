using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using System;
using HaloOnline.Server.Core.Repository;
using System.Security.Claims;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("FriendsService.svc")]
    public class GetSubscriptionsController : ApiController
    {
        private readonly IHaloDbContext _dbContext;

        public GetSubscriptionsController(IHaloDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("GetSubscriptions")]
        public IHttpActionResult GetSubscriptions()
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;

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
                                    UserList = new List<object>
                                    {
                                        new
                                        {
                                            Id = 0
                                        }
                                    }
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
    }
}
