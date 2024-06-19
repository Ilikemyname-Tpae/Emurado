using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Dapper;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.UserStorage;
using HaloOnline.Server.Core.Repository;
using HaloOnline.Server.Model.User;
using HaloOnline.Server.Model.UserStorage;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class UserStorageController : ApiController
    {
        [HttpPost]
        public SetPrivateDataResult SetPrivateData(SetPrivateDataRequest request)
        {
            switch (request.ContainerName)
            {
                case DataContainerTypes.Preferences:
                    var preferences = Preferences.Deserialize(request.Data);
                    break;
                default:
                    throw new ArgumentException("ContainerName");
            }

            return new SetPrivateDataResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public GetPrivateDataResult GetPrivateData(GetPrivateDataRequest request)
        {
            AbstractData data;
            switch (request.ContainerName)
            {
                case DataContainerTypes.Preferences:
                    var preference = new Preferences
                    {
                        LastReadNewsUnknownValue = 1,
                        LastReadNewsName = "news1"
                    };
                    data = preference.Serialize();
                    break;
                default:
                    throw new ArgumentException("ContainerName");
            }

            return new GetPrivateDataResult
            {
                Result = new ServiceResult<AbstractData>
                {
                    Data = data
                }
            };
        }

        [HttpPost]
        public async Task<IHttpActionResult> GetPublicData(GetPublicDataRequest request)
        {
            try
            {
                int userId = request?.Users?.FirstOrDefault()?.Id ?? -1;

                if (userId == -1)
                {
                    return BadRequest("Invalid user ID");
                }

                string containerName = request.ContainerName.ToLower();

                string data = null;

                using (var dbContext = new HaloDbContext())
                {
                    var publicData = await dbContext.PublicData.FirstOrDefaultAsync(pd => pd.UserId == userId);

                    if (publicData == null)
                    {
                        return NotFound();
                    }

                    switch (containerName)
                    {
                        case "armor_loadouts":
                            data = publicData.armor_loadouts;
                            break;
                        case "customizations":
                            data = publicData.customizations;
                            break;
                        case "weapon_loadouts":
                            data = publicData.weapon_loadouts;
                            break;
                        case "preferences":
                            data = publicData.preferences;
                            break;
                        default:
                            return BadRequest($"Invalid containerName: {request.ContainerName}");
                    }

                    if (data == null)
                    {
                        return NotFound();
                    }

                    data = data.Replace("\r\n", "").Replace("\\", "");
                }

                var parsedData = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);

                var result = new GetPublicDataResult
                {
                    Result = new ServiceResult<List<PerUser>>
                    {
                        Data = new List<PerUser>
                        {
                            new PerUser
                            {
                                User = new UserId
                                {
                                    Id = userId
                                },
                                PerUserData = parsedData
                            }
                        }
                    }
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
