using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Web.Http;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Repository;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class NicknameChangeController : ApiController
    {
        private readonly IUserBaseDataRepository _userBaseDataRepository;
        private readonly IHaloDbContext _dbContext;
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        public NicknameChangeController(IUserBaseDataRepository userBaseDataRepository, IHaloDbContext dbContext)
        {
            _userBaseDataRepository = userBaseDataRepository;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("NicknameChange")]
        [Authorize]
        public async Task<IHttpActionResult> NicknameChange([FromBody] Dictionary<string, string> requestBody)
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;

                if (requestBody != null && requestBody.TryGetValue("nickname", out var newNickname))
                {
                    var userBaseData = new UserBaseData
                    {
                        User = new UserId
                        {
                            Id = userId
                        },
                        Nickname = newNickname,
                        BattleTag = ""
                    };

                    await _userBaseDataRepository.SetUserBaseDataAsync(userBaseData);

                    var result = new
                    {
                        NicknameChangeResult = new
                        {
                            retCode = 0
                        }
                    };

                    return Ok(result);
                }
                else
                {
                    return BadRequest(":(");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
