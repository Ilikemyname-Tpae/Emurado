using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly ISessionRepository _sessionRepository;
        private readonly IPartyRepository _partyRepository;
        private readonly IPartyMemberRepository _partyMemberRepository;
        private readonly IUserPresenceRepository _userPresenceRepository;

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
            return new MatchmakeStartResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public ReportOnlineStatsResult ReportOnlineStats(ReportOnlineStatsRequest request)
        {

            return new ReportOnlineStatsResult
            {
                Result = new ServiceResult<OnlineStats>
                {
                    Data = new OnlineStats
                    {
                        UsersMainMenu = 51,
                        UsersQueue = 50,
                        UsersIngame = 50,
                        UsersRematch = 50,
                        MatchmakeSessions = 55
                    }
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
                            PlayersNumber = 1
                        },
                        new PlaylistStat
                        {
                            Playlist = "playlist2",
                            PlayersNumber = 2
                        },
                        new PlaylistStat
                        {
                            Playlist = "playlist3",
                            PlayersNumber = 3
                        },
                    }
                }
            };
        }
    }
}
