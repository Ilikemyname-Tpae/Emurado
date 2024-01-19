using HaloOnline.Server.Model.User;
using System.Collections.Generic;

namespace HaloOnline.Server.Model.UserStorage
{
    public class PerUser
    {
        public UserId User { get; set; }
        public Dictionary<string, object> PerUserData { get; set; }
    }
}
