using HaloOnline.Server.Model.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaloOnline.Server.Core.Http.Model.UserStorage
{
    public class GetPublicDataRequest
    {
        [JsonProperty("users")]
        public List<UserId> Users { get; set; }

        [JsonProperty("containerName")]
        public string ContainerName { get; set; }
    }
}
public class PublicDataRequest
{
    public string ContainerName { get; set; }
    public object Data { get; set; }
}
