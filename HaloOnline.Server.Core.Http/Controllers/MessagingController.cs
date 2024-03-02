using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Messaging;
using HaloOnline.Server.Model.Messaging;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [Authorize]
    public class MessagingController : ApiController
    {
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        public MessagingController()
        {
            if (Channels == null)
            {
                Channels = new List<Channel>();
            }
        }

        public static List<Channel> Channels { get; set; }


        [HttpPost]
        public LeaveChannelsResult LeaveChannels(LeaveChannelsRequest request)
        {
            return new LeaveChannelsResult
            {
                Result = new ServiceResult<List<Channel>>
                {
                    ReturnCode = 0,
                    Data = Channels
                }
            };
        }

        [HttpPost]
        public SendResult Send(SendRequest request)
        {
            int userId;
            this.TryGetUserId(out userId);

            var channel = Channels.FirstOrDefault(c => c.Name == request.ChannelName);
            bool sent = false;
            if (channel != null)
            {
                channel.Version++;
                channel.Messages.Add(new ChannelMessage
                {
                    From = new UserId
                    {
                        Id = userId
                    },
                    Text = request.Message,
                    Timestamp = DateTime.Now,
                    Version = channel.Version
                });
                sent = true;
            }

            return new SendResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = sent
                }
            };
        }
    }
}