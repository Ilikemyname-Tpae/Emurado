using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Dapper;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("MessagingService.svc")]
    public class JoinChannelsController : ApiController
    {
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

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
            var prefix = GetChannelPrefix(channelName);
            if (prefix != null)
            {
                using (var connection = await GetOpenConnectionAsync())
                {
                    await connection.ExecuteAsync(
                        @"DELETE FROM Channel 
                  WHERE Name LIKE @Prefix AND UserId = @UserId",
                        new { Prefix = $"{prefix}%", UserId = userId });

                    await connection.ExecuteAsync(
                        @"DELETE FROM ChannelMembers 
                  WHERE ChannelName = @ChannelName AND UserId = @UserId",
                        new { ChannelName = channelName, UserId = userId });

                    await connection.ExecuteAsync(
                        @"INSERT INTO Channel (Name, Version, UserId)
                  VALUES (@Name, @Version, @UserId)",
                        new { Name = channelName, Version = 1, UserId = userId });
                }
            }
        }

        private async Task AddMemberToChannelAsync(string channelName, int userId)
        {
            using (var connection = await GetOpenConnectionAsync())
            {
                await connection.ExecuteAsync(
                    @"INSERT INTO ChannelMembers (ChannelName, UserId)
                      VALUES (@ChannelName, @UserId)",
                    new { ChannelName = channelName, UserId = userId });
            }
        }

        private string GetChannelPrefix(string channelName)
        {
            if (channelName.StartsWith("#general"))
                return "#general";
            else if (channelName.StartsWith("#private"))
                return "#private";
            else if (channelName.StartsWith("#party"))
                return "#party";
            else if (channelName.StartsWith("#game"))
                return "#game";
            else
                return null;
        }

        private async Task<object> GetChannelInfoAsync(string channelName, int userId)
        {
            using (var connection = await GetOpenConnectionAsync())
            {
                var result = await connection.QueryFirstOrDefaultAsync(
                    @"SELECT Id, Name, Version FROM Channel
                      WHERE Name = @Name AND UserId = @UserId",
                    new { Name = channelName, UserId = userId });

                if (result != null)
                {
                    return new
                    {
                        Name = result.Name,
                        Version = result.Version,
                        Messages = new List<object>(),
                        Members = new[] { new { Id = userId } }
                    };
                }
            }

            return null;
        }

        private async Task<SQLiteConnection> GetOpenConnectionAsync()
        {
            var connection = new SQLiteConnection(ConnectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
