using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Interface.Services;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.SessionControl;
using HaloOnline.Server.Core.Repository;
using HaloOnline.Server.Model.SessionControl;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class SessionControlController : ApiController, ISessionControlService
    {
        private readonly HaloDbContext _dbContext = new HaloDbContext();

        private int GetCurrentUserId()
        {
            var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;
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
                            Id = "0f24620f-7fbe-44e3-a776-6d7097s8as0d87"
                        },
                        DedicatedServer = new DedicatedServer
                        {
                            ServerId = "d37e4cc7-eef4-4153-96b1-be515sa8af3ce",
                            ServerAddress = "000.000.0.000",
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
                var party = _dbContext.Parties.FirstOrDefault(p => p.Id == partyId && p.MatchmakeState != 2);
                if (party != null)
                {
                    party.MatchmakeState = 2;
                    _dbContext.SaveChanges();
                }
            }
        }

        private string GetPartyIdForCurrentUser()
        {
            int userId = GetCurrentUserId();
            var partyMember = _dbContext.PartyMembers.FirstOrDefault(pm => pm.UserId == userId);
            return partyMember?.PartyId;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
