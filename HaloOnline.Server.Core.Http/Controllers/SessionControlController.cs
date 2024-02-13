using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.SessionControl;
using HaloOnline.Server.Model.SessionControl;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class SessionControlController : ApiController, ISessionControlService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionControlController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        
        [HttpPost]
        public ClientGetStatusResult ClientGetStatus(ClientGetStatusRequest request)
        {
            return new ClientGetStatusResult
            {
                Result = new ServiceResult<ClientStatus>
                {
                    Data = new ClientStatus
                    {
                        Game = new SessionId
                        {
                            Id = ""
                        },
                        DedicatedServer = new DedicatedServer
                        {
                            ServerId = "",
                            ServerAddress = "",
                            Port = 11774
                        }
                    }
                }
            };
        }

        [HttpPost]
        public GetSessionBasicDataResult GetSessionBasicData(GetSessionBasicDataRequest request)
        {
            IEnumerable<SessionBasicData> sessionBasicData = request.Sessions
                .Select(session => _sessionRepository.FindBySessionIdAsync(session.Id).Result)
                .Where(basicData => basicData != null)
                .Select(session => new SessionBasicData
                {
                    SessionId = session.Id,
                    MapId = session.MapId,
                    ModeId = session.ModeId,
                    Started = session.Started,
                    Finished = session.Finished
                });

            return new GetSessionBasicDataResult
            {
                Result = new ServiceResult<List<SessionBasicData>>
                {
                    ReturnCode = 0,
                    Data = sessionBasicData.ToList()
                }
            };
        }

        [HttpPost]
        public GetSessionChainResult GetSessionChain(GetSessionChainRequest request)
        {
            return new GetSessionChainResult
            {
                Result = new ServiceResult<List<SessionChain>>
                {
                    Data = new List<SessionChain>
                    {
                        new SessionChain
                        {
                            User = "",
                            Sessions = new List<SessionId>
                            {
                                new SessionId
                                {
                                    Id = ""
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
