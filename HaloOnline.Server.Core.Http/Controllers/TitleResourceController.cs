using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using HaloOnline.Server.Model.TitleResource;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("TitleResourceService.svc")]
    public class GetTitleResourceController : ApiController
    {
        [HttpPost]
        [Route("GetTitleConfiguration")]
        public IHttpActionResult GetTitleResource()
        {
            try
            {
                string solutionDirectory = SolutionDirectoryGetter.GetSolutionDirectory();
                string instancesFolder = Path.Combine(solutionDirectory, "HaloOnline.Server.Core.Http\\Controllers\\instances");
                string[] filePaths = {
                 "ASSIGN_KIT.json", "ADVERTISMENT.json", "UI_DESC.json", "WEAPON.json", "PLAYLIST.json", "COLOR.json",
                    "GRENADE.json", "CONSUMABLE.json", "CONS_UI_STATS.json", "WPN_UI_STATS.json", "MOTD.json", "SCORING_EVENT.json",
                    "GAME_MODE.json", "MAP_INFO.json", "MP_DEFAULTS.json", "PLAYER_LEVEL.json", "News.json", "DS_DEFAULTS.json",
                    "CHALLENGE.json", "REWARD.json", "GAMEPLAY_MODIFIER.json"
                }; 

                var combinedInstances = new List<dynamic>();

                foreach (var filePath in filePaths)
                {
                    string fullPath = Path.Combine(instancesFolder, filePath);
                    if (File.Exists(fullPath))
                    {
                        string jsonContent = File.ReadAllText(fullPath);
                        var instances = JsonConvert.DeserializeObject<List<dynamic>>(jsonContent);
                        combinedInstances.AddRange(instances);
                    }
                }

                var response = new
                {
                    GetTitleConfigurationResult = new
                    {
                        retCode = 0,
                        data = new
                        {
                            combinationHash = "",
                            instances = combinedInstances
                        }
                    }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}