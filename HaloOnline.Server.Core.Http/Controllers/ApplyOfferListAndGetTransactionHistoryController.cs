using HaloOnline.Server.Core.Repository;
using HaloOnline.Server.Core.Repository.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class ApplyOfferListAndGetTransactionHistoryController : ApiController
    {
        private readonly HaloDbContext _context = new HaloDbContext();

        [HttpPost]
        [Route("ApplyOfferListAndGetTransactionHistory")]
        public async Task<IHttpActionResult> ApplyOfferListAndGetTransactionHistory([FromBody] JObject requestData)
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                string offerId = requestData["offerIds"]?.FirstOrDefault()?.ToString();

                if (string.IsNullOrEmpty(offerId))
                {
                    return BadRequest("Invalid or missing offer ID in the request.");
                }

                var offer = await _context.ItemOffers.FirstOrDefaultAsync(o => o.ItemId == offerId);
                if (offer == null)
                {
                    return BadRequest("Offer not found.");
                }

                var user = await _context.Users.Include(u => u.UserStates).FirstOrDefaultAsync(u => u.Id == userId);
                if (user == null)
                {
                    return BadRequest("User not found.");
                }

                int previousValue = offerId.Contains("_cr") ? user.Credits : user.Gold;
                int offerPrice = offer.Price;
                long unixTimestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

                await UpdateRemainingValueAsync(user, offerId, previousValue, offerPrice);
                await InsertTransactionDataAsync(user, offerId, previousValue, previousValue - offerPrice, unixTimestamp);

                var transaction = new
                {
                    transactionItems = new List<object> {
                    new {
                        stateName = offerId,
                        stateType = offerId.Contains("_cr") ? 2 : 3,
                        ownType = offerId.StartsWith("challenge") ? 1 : 2,
                        operationType = 0,
                        initialValue = offerId.StartsWith("challenge") ? 0 : previousValue,
                        resultingValue = offerId.StartsWith("challenge") ? 0 : previousValue - offerPrice,
                        deltaValue = offerId.StartsWith("challenge") ? 0 : previousValue - (previousValue - offerPrice),
                        descId = 0
                    }
                },
                    sessionId = Guid.NewGuid().ToString(),
                    referenceId = Guid.NewGuid().ToString(),
                    offerId = Guid.NewGuid().ToString(),
                    timeStamp = unixTimestamp,
                    operationType = 0,
                    extendedInfoItems = new List<object> {
                    new {
                        Key = "",
                        Value = ""
                    }
                }
                };

                var data = new
                {
                    ApplyOfferListAndGetTransactionHistory = new
                    {
                        retCode = 0,
                        data = new
                        {
                            totalResults = 1,
                            transactions = new List<object> {
                            transaction
                        }
                        }
                    }
                };

                return Ok(data);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private async Task UpdateRemainingValueAsync(User user, string offerId, int previousValue, int offerPrice)
        {
            if (offerId == "ranger_kit_offer" || offerId == "sniper_kit_offer" || offerId == "tactician_kit_offer")
            {
                UpdateUserStatesForClassSelectToken(user, "class_select_token");
            }
            else if (offerId.StartsWith("challenge"))
            {
                UpdateUserStatesForChallenge(user, "challenge");
            }
            else
            {
                string stateName = offerId.Contains("_cr") ? "Credits" : "Gold";

                UpdateUserCurrency(user, stateName, offerPrice);

                UpdateUserStateValue(user, stateName);
            }

            await _context.SaveChangesAsync();
        }

        private void UpdateUserStatesForClassSelectToken(User user, string stateName)
        {
            var userState = user.UserStates.FirstOrDefault(us => us.StateName == stateName);
            if (userState != null)
            {
                userState.OwnType = 0;
                userState.Value = 0;
            }
        }

        private void UpdateUserStatesForChallenge(User user, string stateName)
        {
            var userState = user.UserStates.FirstOrDefault(us => us.StateName == stateName);
            if (userState != null)
            {
                userState.OwnType = 1;
                userState.Value = 1;
            }
        }

        private void UpdateUserCurrency(User user, string stateName, int offerPrice)
        {
            if (stateName == "Credits")
            {
                user.Credits -= offerPrice;
            }
            else if (stateName == "Gold")
            {
                user.Gold -= offerPrice;
            }
        }

        private void UpdateUserStateValue(User user, string stateName)
        {
            var userState = user.UserStates.FirstOrDefault(us => us.StateName == stateName);
            if (userState != null)
            {
                if (stateName == "Credits")
                {
                    userState.Value = user.Credits;
                }
                else if (stateName == "Gold")
                {
                    userState.Value = user.Gold;
                }
            }
        }

        private async Task InsertTransactionDataAsync(User user, string offerId, int initialValue, int resultingValue, long unixTimestamp)
        {
            string sanitizedOfferId = offerId.EndsWith("_cr") ? offerId.Substring(0, offerId.Length - 3) : offerId;
            bool isChallengeOffer = offerId.StartsWith("challenge");

            var transaction = new Transaction
            {
                UserId = user.Id,
                OfferId = offerId,
                InitialValue = isChallengeOffer ? 0 : initialValue,
                ResultingValue = isChallengeOffer ? 0 : resultingValue,
                DeltaValue = isChallengeOffer ? 0 : initialValue - resultingValue,
                OperationType = 2,
                SessionId = Guid.NewGuid().ToString(),
                ReferenceId = Guid.NewGuid().ToString(),
            };

            _context.Transactions.Add(transaction);

            var transactionHistory = new TransactionHistory
            {
                UserId = user.Id,
                StateName = sanitizedOfferId,
                StateType = 4,
                OwnType = isChallengeOffer ? 1 : 2,
                OperationType = 0,
                InitialValue = isChallengeOffer ? 0 : 3600,
                ResultingValue = isChallengeOffer ? 0 : 3600,
                DeltaValue = isChallengeOffer ? 0 : initialValue - resultingValue,
                DescId = 0,
                SessionId = transaction.SessionId,
                ReferenceId = transaction.ReferenceId,
                OfferId = offerId,
                TimeStamp = unixTimestamp,
                ExtendedInfoKey = "",
                ExtendedInfoValue = ""
            };

            _context.TransactionHistory.Add(transactionHistory);

            await _context.SaveChangesAsync();
        }
    }
}