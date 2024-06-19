using HaloOnline.Server.Core.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class GetUsersBaseDataController : ApiController
    {
        private readonly IHaloDbContext _dbContext;

        public GetUsersBaseDataController(IHaloDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("GetUsersBaseData")]
        public async Task<IHttpActionResult> GetUsersBaseData()
        {
            try
            {
                var requestBody = await Request.Content.ReadAsStringAsync();

                dynamic requestData = JsonConvert.DeserializeObject(requestBody);
                int userId = requestData?.users?[0]?.Id ?? -1;

                var userData = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);

                if (userData != null)
                {
                    var result = new
                    {
                        GetUsersBaseDataResult = new
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
                                    Nickname = userData.Nickname,
                                    BattleTag = userData.BattleTag,
                                    Level = userData.Level,
                                    Clan = new
                                    {
                                        Id = 0
                                    },
                                    ClanTag = ""
                                }
                            }
                        }
                    };

                    return Ok(result);
                }
                else
                {
                    return BadRequest("User not found");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
