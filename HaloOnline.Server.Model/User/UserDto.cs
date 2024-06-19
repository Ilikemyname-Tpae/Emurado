using HaloOnline.Server.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaloOnline.Server.Core.Http.Model.User
{
    internal class UserDto : UserId
    {
        public int Id { get; set; }
    }
}