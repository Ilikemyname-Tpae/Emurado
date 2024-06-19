using System;
using System.Data.Entity;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.UserStorage;
using HaloOnline.Server.Core.Repository;
using HaloOnline.Server.Core.Repository.Model;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserStorageService.svc")]
    public class SetPublicDataController : ApiController
    {
        [HttpPost]
        [Route("SetPublicData")]
        public async Task<IHttpActionResult> SetPublicData([FromBody] PublicDataRequest requestData)
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                using (var dbContext = new HaloDbContext())
                {
                    try
                    {
                        await UpsertData(dbContext, userId, requestData);
                    }
                    catch (Exception ex)
                    {
                        return InternalServerError(ex);
                    }
                }

                var response = new
                {
                    SetPublicDataResult = new
                    {
                        retCode = 0,
                        data = true
                    }
                };

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Error saving data.");
            }
        }

        private async Task UpsertData(HaloDbContext dbContext, int userId, PublicDataRequest requestData)
        {
            if (requestData == null)
            {
                throw new ArgumentNullException(nameof(requestData));
            }

            var publicData = await dbContext.PublicData.FirstOrDefaultAsync(pd => pd.UserId == userId);

            if (publicData == null)
            {
                publicData = new PublicData { UserId = userId };
                dbContext.PublicData.Add(publicData);
            }

            PropertyInfo property = typeof(PublicData).GetProperty(requestData.ContainerName, BindingFlags.Public | BindingFlags.Instance);
            if (property == null)
            {
                throw new ArgumentException($"Invalid containerName: {requestData.ContainerName}");
            }

            property.SetValue(publicData, requestData.Data.ToString());

            await dbContext.SaveChangesAsync();
        }
    }
}