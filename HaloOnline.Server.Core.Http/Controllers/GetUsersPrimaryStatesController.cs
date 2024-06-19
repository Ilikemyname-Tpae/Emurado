using HaloOnline.Server.Core.Repository.Model;
using HaloOnline.Server.Core.Repository;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class GetUsersPrimaryStatesController : ApiController
    {
        private readonly HaloDbContext _context;

        public GetUsersPrimaryStatesController()
        {
            _context = new HaloDbContext();
        }

        [HttpPost]
        [Route("GetUsersPrimaryStates")]
        [Authorize]
        public async Task<IHttpActionResult> GetUsersPrimaryStates()
        {
            try
            {
                var requestBody = await Request.Content.ReadAsStringAsync();
                dynamic requestData = JsonConvert.DeserializeObject(requestBody);
                int userId = requestData?.users?[0]?.Id ?? -1;

                if (userId == -1)
                {
                    return BadRequest("Invalid user ID.");
                }

                var userData = await GetOrCreateUserPrimaryState(userId);

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
                                    Id = userData.UserId
                                },
                                userData.Xp,
                                userData.Kills,
                                userData.Deaths,
                                userData.Assists,
                                userData.Suicides,
                                userData.TotalMatches,
                                userData.Victories,
                                Defeats = userData.TotalMatches - userData.Victories,
                                userData.TotalWP,
                                userData.TotalTimePlayed,
                                userData.TotalTimeOnline
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

        private async Task<UserPrimaryState> GetOrCreateUserPrimaryState(int userId)
        {
            var userPrimaryState = await _context.UserPrimaryState.FirstOrDefaultAsync(u => u.UserId == userId);

            if (userPrimaryState == null)
            {
                userPrimaryState = new UserPrimaryState
                {
                    UserId = userId,
                    Xp = 0,
                    Kills = 0,
                    Deaths = 0,
                    Assists = 0,
                    Suicides = 0,
                    TotalMatches = 0,
                    Victories = 0,
                    TotalWP = 0,
                    TotalTimePlayed = 0,
                    TotalTimeOnline = 0
                };

                _context.UserPrimaryState.Add(userPrimaryState);
                await _context.SaveChangesAsync();
            }

            return userPrimaryState;
        }
    }
}
