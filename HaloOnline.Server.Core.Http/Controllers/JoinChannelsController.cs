using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using HaloOnline.Server.Core.Repository;
using HaloOnline.Server.Core.Repository.Model;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("MessagingService.svc")]
    public class JoinChannelsController : ApiController
    {
        private readonly HaloDbContext dbContext = new HaloDbContext();

        [HttpPost]
        [Route("JoinChannels")]
        [Authorize]
        public async Task<IHttpActionResult> JoinChannels()
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                var requestBody = await Request.Content.ReadAsStringAsync();
                dynamic requestData = JsonConvert.DeserializeObject(requestBody);
                var channelNames = requestData?.channelNames?.ToObject<List<string>>();

                var channelInfoList = new List<object>();

                if (channelNames != null)
                {
                    foreach (var channelName in channelNames)
                    {
                        await ReplaceChannelInDatabaseAsync(channelName, userId);
                        await AddMemberToChannelAsync(channelName, userId);
                        var channelInfo = await GetChannelInfoAsync(channelName, userId);
                        if (channelInfo != null)
                            channelInfoList.Add(channelInfo);
                    }
                }

                var result = new
                {
                    JoinChannelsResult = new
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

        private async Task ReplaceChannelInDatabaseAsync(string channelName, int userId)
        {
            await Task.Run(async () =>
            {
                var channel = await dbContext.Channels
                    .FirstOrDefaultAsync(c => c.Name == channelName && c.Users.Any(u => u.UserId == userId));

                if (channel != null)
                {
                    dbContext.Channels.Remove(channel);
                    await dbContext.SaveChangesAsync();
                }

                var newChannel = new Channel
                {
                    Name = channelName,
                    Version = 1,
                    Users = new List<ChannelUser> { new ChannelUser { UserId = userId } }
                };

                dbContext.Channels.Add(newChannel);
                await dbContext.SaveChangesAsync();
            });
        }

        private async Task AddMemberToChannelAsync(string channelName, int userId)
        {
            await Task.Run(async () =>
            {
                var channel = await dbContext.Channels.FirstOrDefaultAsync(c => c.Name == channelName);
                if (channel != null)
                {
                    var existingMember = await dbContext.ChannelsUsers
                        .FirstOrDefaultAsync(cu => cu.ChannelId == channel.Id && cu.UserId == userId);

                    if (existingMember == null)
                    {
                        var newMember = new ChannelUser
                        {
                            ChannelId = channel.Id,
                            UserId = userId
                        };

                        dbContext.ChannelsUsers.Add(newMember);
                        await dbContext.SaveChangesAsync();
                    }
                }
            });
        }


        private async Task<object> GetChannelInfoAsync(string channelName, int userId)
        {
            var channel = await dbContext.Channels
                .Include(c => c.Users)
                .FirstOrDefaultAsync(c => c.Name == channelName && c.Users.Any(u => u.UserId == userId));

            if (channel != null)
            {
                return new
                {
                    Name = channel.Name,
                    Version = channel.Version,
                    Messages = new List<object>(),
                    Members = channel.Users.Select(u => new { Id = u.UserId }).ToList()
                };
            }

            return null;
        }
    }
}
