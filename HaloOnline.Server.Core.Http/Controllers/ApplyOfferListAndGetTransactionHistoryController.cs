using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class ApplyOfferListAndGetTransactionHistoryController : ApiController
    {
        private string connectionString = "Data Source=halodb.sqlite";

        [HttpPost]
        [Route("ApplyOfferListAndGetTransactionHistory")]
        public IHttpActionResult ApplyOfferListAndGetTransactionHistory([FromBody] JObject requestData)
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

                int offerPrice = GetOfferPrice(offerId);
                int previousValue = -1;

                if (offerId.Contains("_cr"))
                {
                    previousValue = GetLatestRemainingCreditsValue(userId);
                }
                else
                {
                    previousValue = GetLatestRemainingGoldValue(userId);
                }

                if (previousValue == -1)
                {
                    return InternalServerError(new Exception("Failed to retrieve previous value for the transaction."));
                }

                long unixTimestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);

                var transaction = new
                {
                    transactionItems = new List<object> {
                        new {
                            stateName = offerId,
                            stateType = offerId.Contains("_cr") ? 2 : 3,
                            ownType = 0,
                            operationType = 0,
                            initialValue = previousValue,
                            resultingValue = previousValue - offerPrice,
                            deltaValue = previousValue - (previousValue - offerPrice),
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

                UpdateRemainingValue(userId, offerId, previousValue, offerPrice);

                InsertTransactionData(userId, offerId, previousValue, previousValue - offerPrice);

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

        private void UpdateRemainingValue(int userId, string offerId, int previousValue, int offerPrice)
        {
            if (offerId.Contains("_cr"))
            {
                UpdateRemainingCreditsFile(userId, previousValue - offerPrice);
            }
            else
            {
                UpdateRemainingGoldFile(userId, previousValue - offerPrice);
            }
        }

        private int GetLatestRemainingGoldValue(int userId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT Gold FROM User WHERE Id = @UserId", connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    var result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 10150;
                }
            }
        }
        private int GetLatestRemainingCreditsValue(int userId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT Credits FROM User WHERE Id = @UserId", connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    var result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 1000;
                }
            }
        }

        private int GetOfferPrice(string offerId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT Price FROM ItemOffers WHERE ItemId = @ItemId", connection))
                {
                    command.Parameters.AddWithValue("@ItemId", offerId);
                    var result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        private void UpdateRemainingGoldFile(int userId, int newValue)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var updateCommandUser = new SQLiteCommand("UPDATE User SET Gold = @Gold WHERE Id = @UserId", connection))
                    {
                        updateCommandUser.Parameters.AddWithValue("@UserId", userId);
                        updateCommandUser.Parameters.AddWithValue("@Gold", newValue);
                        updateCommandUser.ExecuteNonQuery();
                    }

                    using (var updateCommandUserStates = new SQLiteCommand("UPDATE UserStates SET Value = @Value WHERE UserId = @UserId AND StateName = 'Gold'", connection))
                    {
                        updateCommandUserStates.Parameters.AddWithValue("@UserId", userId);
                        updateCommandUserStates.Parameters.AddWithValue("@Value", newValue);
                        updateCommandUserStates.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void UpdateRemainingCreditsFile(int userId, int newValue)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var updateCommandUser = new SQLiteCommand("UPDATE User SET Credits = @Credits WHERE Id = @UserId", connection))
                    {
                        updateCommandUser.Parameters.AddWithValue("@UserId", userId);
                        updateCommandUser.Parameters.AddWithValue("@Credits", newValue);
                        updateCommandUser.ExecuteNonQuery();
                    }

                    using (var updateCommandUserStates = new SQLiteCommand("UPDATE UserStates SET Value = @Value WHERE UserId = @UserId AND StateName = 'Credits'", connection))
                    {
                        updateCommandUserStates.Parameters.AddWithValue("@UserId", userId);
                        updateCommandUserStates.Parameters.AddWithValue("@Value", newValue);
                        updateCommandUserStates.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void InsertTransactionData(int userId, string offerId, int initialValue, int resultingValue)
        {
            string sanitizedOfferId = offerId.EndsWith("_cr") ? offerId.Substring(0, offerId.Length - 3) : offerId;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                long unixTimestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);

                using (var command = new SQLiteCommand(
                    "INSERT INTO Transactions (UserId, OfferId, InitialValue, ResultingValue, DeltaValue, OperationType, SessionId, ReferenceId) " +
                    "VALUES (@UserId, @OfferId, @InitialValue, @ResultingValue, @DeltaValue, @OperationType, @SessionId, @ReferenceId)", connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@OfferId", offerId);
                    command.Parameters.AddWithValue("@InitialValue", 3600);
                    command.Parameters.AddWithValue("@ResultingValue", 3600);
                    command.Parameters.AddWithValue("@DeltaValue", initialValue - resultingValue);
                    command.Parameters.AddWithValue("@OperationType", 2);
                    command.Parameters.AddWithValue("@SessionId", Guid.NewGuid().ToString());
                    command.Parameters.AddWithValue("@ReferenceId", Guid.NewGuid().ToString());
                    command.ExecuteNonQuery();
                }

                using (var commandHistory = new SQLiteCommand(
                    "INSERT INTO TransactionHistory (UserId, StateName, StateType, OwnType, OperationType, InitialValue, ResultingValue, DeltaValue, DescId, SessionId, ReferenceId, OfferId, TimeStamp, ExtendedInfoKey, ExtendedInfoValue) " +
                    "VALUES (@UserId, @StateName, @StateType, @OwnType, @OperationType, @InitialValue, @ResultingValue, @DeltaValue, @DescId, @SessionId, @ReferenceId, @OfferId, @TimeStamp, @ExtendedInfoKey, @ExtendedInfoValue)", connection))
                {
                    commandHistory.Parameters.AddWithValue("@UserId", userId);
                    commandHistory.Parameters.AddWithValue("@StateName", sanitizedOfferId);
                    commandHistory.Parameters.AddWithValue("@StateType", 4);
                    commandHistory.Parameters.AddWithValue("@OwnType", 2);
                    commandHistory.Parameters.AddWithValue("@OperationType", 0);
                    commandHistory.Parameters.AddWithValue("@InitialValue", 3600);
                    commandHistory.Parameters.AddWithValue("@ResultingValue", 3600);
                    commandHistory.Parameters.AddWithValue("@DeltaValue", initialValue - resultingValue);
                    commandHistory.Parameters.AddWithValue("@DescId", 2);
                    commandHistory.Parameters.AddWithValue("@SessionId", Guid.NewGuid().ToString());
                    commandHistory.Parameters.AddWithValue("@ReferenceId", Guid.NewGuid().ToString());
                    commandHistory.Parameters.AddWithValue("@OfferId", sanitizedOfferId);
                    commandHistory.Parameters.AddWithValue("@TimeStamp", unixTimestamp);
                    commandHistory.Parameters.AddWithValue("@ExtendedInfoKey", "");
                    commandHistory.Parameters.AddWithValue("@ExtendedInfoValue", "");
                    commandHistory.ExecuteNonQuery();
                }
            }
        }
    }
 }
