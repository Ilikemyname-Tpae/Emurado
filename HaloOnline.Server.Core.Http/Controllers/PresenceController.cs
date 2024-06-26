﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.Presence;
using HaloOnline.Server.Model.Presence;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [Authorize]
    public class PresenceController : ApiController
    {
        [HttpPost]
        public PresenceDisconnectResult PresenceDisconnect(PresenceDisconnectRequest request)
        {
            int userId;
            this.TryGetUserId(out userId);

            return new PresenceDisconnectResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public PartyKickResult PartyKick(PartyKickRequest request)
        {
            return new PartyKickResult
            {
                Result = new ServiceResult<PartyStatus>
                {
                    Data = new PartyStatus
                    {
                        Party = new PartyId
                        {
                            Id = "1"
                        },
                        SessionMembers = new List<PartyMemberDto>
                        {
                            new PartyMemberDto
                            {
                                User = new UserId
                                {
                                    Id = 1
                                }
                            }
                        },
                        MatchmakeState = 0,
                        GameData = new byte[100]
                    }
                }
            };
        }

        [HttpPost]
        public PartySetGameDataResult PartySetGameData(PartySetGameDataRequest request)
        {
            return new PartySetGameDataResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public CustomGameStartResult CustomGameStart(CustomGameStartRequest request)
        {
            return new CustomGameStartResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public CustomGameStopResult CustomGameStop(CustomGameStopRequest request)
        {
            return new CustomGameStopResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public MatchmakeStartResult MatchmakeStart(MatchmakeStartRequest request)
        {
            string sessionId;

            using (var connection = new SQLiteConnection("Data Source=halodb.sqlite"))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(*) FROM Session";
                    var count = (long)command.ExecuteScalar();
                    if (count == 0)
                    {
                        sessionId = Guid.NewGuid().ToString();

                        command.CommandText = "INSERT INTO Session (Id) VALUES (@Id)";
                        command.Parameters.AddWithValue("@Id", sessionId);
                        command.ExecuteNonQuery();
                    }
                }
            }

            return new MatchmakeStartResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public async Task<ReportOnlineStatsResult> ReportOnlineStats(ReportOnlineStatsRequest request)
        {
            var onlineStats = new OnlineStats
            {
                UsersMainMenu = 0,
                UsersQueue = 0,
                UsersIngame = 0,
                UsersRematch = 0,
                MatchmakeSessions = 0
            };

            return new ReportOnlineStatsResult
            {
                Result = new ServiceResult<OnlineStats>
                {
                    Data = onlineStats
                }
            };
        }

        [HttpPost]
        public GetPlaylistStatResult GetPlaylistStat(GetPlaylistStatRequest request)
        {
            return new GetPlaylistStatResult
            {
                Result = new ServiceResult<List<PlaylistStat>>
                {
                    Data = new List<PlaylistStat>
                    {
                        new PlaylistStat
                        {
                            Playlist = "playlist1",
                            PlayersNumber = 0
                        },
                        new PlaylistStat
                        {
                            Playlist = "playlist2",
                            PlayersNumber = 0
                        },
                    }
                }
            };
        }
    }
}
