using HaloOnline.Server.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class NicknameChangeController : ApiController
    {
        private readonly HaloDbContext _context;

        public NicknameChangeController()
        {
            _context = new HaloDbContext();
        }

        [HttpPost]
        [Route("NicknameChange")]
        [Authorize]
        public async Task<IHttpActionResult> NicknameChange([FromBody] Dictionary<string, string> requestBody)
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                if (userId != -1 && requestBody != null && requestBody.TryGetValue("nickname", out var newNickname))
                {
                    var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

                    if (existingUser == null)
                    {
                        return NotFound();
                    }

                    existingUser.Nickname = newNickname;
                    _context.Entry(existingUser).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

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
