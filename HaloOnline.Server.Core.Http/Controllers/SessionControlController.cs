using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Claims;
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
            SetMatchmakeStateToTwo();

            return new ClientGetStatusResult
            {
                Result = new ServiceResult<ClientStatus>
                {
                    Data = new ClientStatus
                    {
                        Game = new SessionId
                        {
                            Id = "be8d8f19-c350-44be-93c9-334df5701cbe"
                        },
                        DedicatedServer = new DedicatedServer
                        {
                            ServerId = "6bf6c648-e33e-4c7c-9eb1-ae3ab3f4f745",
                            ServerAddress = "000.000.000",
                            Port = 11774
                        }
                    }
                }
            };
        }

        private void SetMatchmakeStateToTwo()
        {
            string partyId = GetPartyIdForCurrentUser();

            if (!string.IsNullOrEmpty(partyId))
            {
                using (var connection = new SQLiteConnection("Data Source=halodb.sqlite;Version=3;"))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand("UPDATE Party SET MatchmakeState = 2 WHERE Id = @partyId AND MatchmakeState != 2", connection))
                    {
                        command.Parameters.AddWithValue("@partyId", partyId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private string GetPartyIdForCurrentUser()
        {
            int userId = GetCurrentUserId();
            using (var connection = new SQLiteConnection("Data Source=halodb.sqlite;Version=3;"))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT PartyId FROM PartyMember WHERE UserId = @userId", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    return command.ExecuteScalar()?.ToString();
                }
            }
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;
        }

        private string GetValueFromLine(string[] lines, string key)
        {
            foreach (string line in lines)
            {
                if (line.StartsWith(key))
                {
                    return line.Substring(key.Length).Trim();
                }
            }
            throw new ArgumentException($"Key '{key}' not found in the file.");
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
