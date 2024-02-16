using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{ // Weird class to have, but its all just testing.
    internal class UserDto : UserId
    {
        public int Id { get; set; }
    }
}