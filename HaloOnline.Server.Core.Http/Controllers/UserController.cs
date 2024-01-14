using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Http.Auth;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.User;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserBaseDataRepository _userBaseDataRepository;
        private readonly IHaloUserManager _userManager;

        public UserController(IHaloUserManager userManager, IUserBaseDataRepository userBaseDataRepository)
        {
            _userManager = userManager;
            _userBaseDataRepository = userBaseDataRepository;
        }

        [HttpPost]
        public SignOutResult SignOut(SignOutRequest request)
        {
            return new SignOutResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public GetUsersByNicknameResult GetUsersByNickname(GetUsersByNicknameRequest request)
        {
            var foundUsers = _userBaseDataRepository.FindUserIdByNicknameAsync(request.NicknamePrefix);

            return new GetUsersByNicknameResult
            {
                Result = new ServiceResult<List<UserId>>
                {
                    Data = foundUsers.Result.ToList()
                }
            };
        }


        [HttpPost]
        public ApplyExternalOfferResult ApplyExternalOffer(ApplyExternalOfferRequest request)
        {
            switch (request.ExternalOfferId)
            {
                case "Gold100":
                    break;
                default:
                    break;
            }
            // TODO: Analyze what the return message should contain.

            return new ApplyExternalOfferResult
            {
                Result = new ServiceResult<string>
                {
                    Data = ""
                }
            };
        }

        [HttpPost]
        public ApplyOfferResult ApplyOffer(ApplyOfferRequest request)
        {
            return new ApplyOfferResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }

        [HttpPost]
        public ApplyOfferListResult ApplyOfferList(ApplyOfferListRequest request)
        {
            return new ApplyOfferListResult
            {
                Result = new ServiceResult<bool>
                {
                    Data = true
                }
            };
        }
    }
}
