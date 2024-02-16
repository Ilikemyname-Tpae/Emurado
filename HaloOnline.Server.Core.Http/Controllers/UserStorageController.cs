using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.UserStorage;
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
        public IHttpActionResult GetPublicData(GetPublicDataRequest request)
        {
            try
            {
                int userId = request?.Users?.FirstOrDefault()?.Id ?? -1;

                string data;

                using (SQLiteConnection connection = new SQLiteConnection("Data Source=halodb.sqlite;Version=3;"))
                {
                    connection.Open();

                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = $"SELECT {request.ContainerName} FROM PublicData WHERE UserId = @userId";
                        command.Parameters.AddWithValue("@userId", userId);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    using (var textReader = reader.GetTextReader(0))
                                    {
                                        data = textReader.ReadToEnd();
                                    }
                                    // will clean up after test
                                    data = data.Replace("\r\n", "").Replace("\\", "");
                                }
                                else
                                {
                                    return NotFound();
                                }
                            }
                            else
                            {
                                return NotFound();
                            }
                        }
                    }
                }

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
                                PerUserData = JsonConvert.DeserializeObject<Dictionary<string, object>>(data)
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
