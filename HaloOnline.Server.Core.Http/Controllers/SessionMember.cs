namespace HaloOnline.Server.Model.Presence
{
    public class SessionMember
    {
        public bool IsOwner { get; set; }
        public Core.Repository.Model.User User { get; internal set; }
    }
}
