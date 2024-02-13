using HaloOnline.Server.Model.SessionControl;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Model.Presence
{
    public class MatchmakeMember
    {
        public UserId User { get; set; }
        public PartyId Party { get; set; }
        public bool IsOwner { get; set; }
        public string SessionId { get; set; }
        public SessionId Session { get; set; }
    }
}