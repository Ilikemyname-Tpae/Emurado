using System;
using System.Collections.Generic;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.GameStatistics;
using HaloOnline.Server.Model.GameStatistics;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class GameStatisticsController : ApiController, IGameStatisticsService
    {
        [HttpPost]
        public CheckNewUserChallengesResult CheckNewUserChallenges([FromBody] CheckNewUserChallengesRequest request)
        {
            return new CheckNewUserChallengesResult
            {
                ServiceResult = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public GetUserChallengesResult GetUserChallenges(GetUserChallengesRequest request)
        {
            return new GetUserChallengesResult
            {
                Result = new ServiceResult<UserChallenges>
                {
                    Data = new UserChallenges
                    {
                        Version = 0,
                        Challenges = new List<UserChallenge>
                        {
                            new UserChallenge
                            {
                                ChallengeId = "challenge_oracle_1",
                                Progress = 1,
                                Counters = new List<UserChallengeCounter>
                                {
                                    new UserChallengeCounter
                                    {
                                        CounterName = "challenge_oracle_1",
                                        CurrentValue = 400,
                                        MaxValue = 500
                                    }
                                },
                                FinishedAtUnixMilliseconds = 1735689600,
                                StartDateUnixMilliseconds = DateTime.Now,
                                EndDateUnixMilliseconds = 1735689600,
                                Rewards = new List<ChallengeReward>
                                {
                                    new ChallengeReward
                                    {
                                        Name = "assault_rifle_v2",
                                        Count = 1
                                    },
                                }

                            },
                        }
                    }
                }
            };
        }
    }
}
