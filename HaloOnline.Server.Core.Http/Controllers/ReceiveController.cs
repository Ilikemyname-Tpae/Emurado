using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using HaloOnline.Server.Core.Repository;
using HaloOnline.Server.Core.Repository.Model;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("MessagingService.svc")]
    public class ReceiveController : ApiController
    {
        private readonly HaloDbContext _dbContext;
        private static readonly ConcurrentDictionary<int, ConcurrentDictionary<int, DateTime>> _userLastSeenMessages = new ConcurrentDictionary<int, ConcurrentDictionary<int, DateTime>>();

        public ReceiveController()
        {
            _dbContext = new HaloDbContext();
        }

        [HttpPost]
        [Route("Receive")]
        public async Task<IHttpActionResult> Receive()
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
                {
                    return Unauthorized();
                }

                await UpdateUserState(userId);
                var channelInfoList = await FetchChannelInfoAsync(userId);

                var result = new
                {
                    ReceiveResult = new
                    {
                        retCode = 0,
                        data = channelInfoList
                    }
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private async Task UpdateUserState(int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                user.State = 1;
                user.IsInvitable = 1;
                await _dbContext.SaveChangesAsync();
            }
        }

        private async Task<List<object>> FetchChannelInfoAsync(int userId)
        {
            var channelInfoList = new List<object>();

            var channels = await _dbContext.Channels
                .Include(c => c.Messages)
                .Include(c => c.Users)
                .Where(c => c.Users.Any(u => u.UserId == userId))
                .ToListAsync();

            foreach (var channel in channels)
            {
                if (!_userLastSeenMessages.TryGetValue(userId, out var userChannels))
                {
                    userChannels = new ConcurrentDictionary<int, DateTime>();
                    _userLastSeenMessages[userId] = userChannels;
                }

                userChannels.TryGetValue(channel.Id, out DateTime lastSeenTimestamp);

                var messages = await FetchChannelMessagesAsync(channel.Id, lastSeenTimestamp);

                var channelInfo = new
                {
                    Id = channel.Id,
                    Name = channel.Name,
                    Version = channel.Version,
                    Messages = messages,
                    Members = channel.Users.Select(u => new { Id = u.UserId }).ToList()
                };

                channelInfoList.Add(channelInfo);

                if (messages.Any())
                {
                    var lastMessage = messages.Last() as dynamic;
                    if (lastMessage?.Timestamp != null)
                    {
                        lastSeenTimestamp = FromUnixTimestamp(lastMessage.Timestamp);
                        userChannels[channel.Id] = lastSeenTimestamp;
                    }
                }
            }

            return channelInfoList;
        }

        private static long ToUnixTimestamp(DateTime dateTime)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(dateTime.ToUniversalTime() - unixEpoch).TotalSeconds;
        }

        private static DateTime FromUnixTimestamp(long timestamp)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return unixEpoch.AddSeconds(timestamp).ToUniversalTime();
        }

        private async Task<List<object>> FetchChannelMessagesAsync(int channelId, DateTime lastSeenTimestamp)
        {
            var messages = await _dbContext.ChannelMessages
                .Where(m => m.ChannelId == channelId && m.Timestamp > lastSeenTimestamp)
                .ToListAsync();

            return messages.Select(m => new
            {
                From = new { Id = m.UserId },
                Text = m.Text,
                Timestamp = ToUnixTimestamp(m.Timestamp)
            }).ToList<object>();
        }
    }
}
