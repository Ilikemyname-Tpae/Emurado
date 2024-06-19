using System.Collections.Generic;

namespace HaloOnline.Server.Core.Http.Model.Messaging
{
    public class LeaveChannelsRequest
    {
        public List<string> ChannelNames { get; set; }
    }
}
