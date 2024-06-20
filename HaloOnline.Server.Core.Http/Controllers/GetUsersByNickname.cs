using System.Linq;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Model.User;
using System.Data.Entity;
using HaloOnline.Server.Core.Repository;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class GetUsersByNicknameController : ApiController
    {
        private readonly HaloDbContext dbContext;

        public GetUsersByNicknameController()
        {
            this.dbContext = new HaloDbContext();
        }

        [HttpPost]
        [Route("GetUsersByNickname")]
        public IHttpActionResult GetUsersByNickname([FromBody] GetUsersByNicknameRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.NicknamePrefix))
            {
                return BadRequest("Invalid request");
            }

            var users = dbContext.Users
                                .Where(u => u.Nickname.ToUpper() == request.NicknamePrefix.ToUpper())
                                .Select(u => new
                                {
                                    Id = u.Id
                                })
                                .ToList();

            if (users.Any())
            {
                var result = new
                {
                    GetUsersByNicknameResult = new
                    {
                        retCode = 0,
                        data = users
                    }
                };

                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
