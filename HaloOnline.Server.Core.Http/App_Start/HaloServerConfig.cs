using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Auth;
using HaloOnline.Server.Model.Clan;
using HaloOnline.Server.Model.Friends;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http
{
    public static class HaloServerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            using (var scope = config.DependencyResolver.BeginScope())
            {
                SeedServer(scope);
            }
        }

        private static void SeedServer(IDependencyScope scope)
        {

            try
            {

            }
            catch (Exception)
            {
                Debug.WriteLine("Server initialization failed.");
            }
        }
    }
}
