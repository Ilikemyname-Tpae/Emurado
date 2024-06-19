using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Dapper;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.User;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class GetTransactionHistoryController : ApiController
    {
        private readonly string connectionString = "Data Source=halodb.sqlite;Pooling=True;Max Pool Size=100;";

        [HttpPost]
        [Route("GetTransactionHistory")]
        public async Task<IHttpActionResult> GetTransactionHistory()
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                await DeductTransactionTimeAsync(userId);

                List<UserTransaction> userTransactions = await GetUserTransactionsAsync(userId);

                return Ok(new GetTransactionHistoryResult
                {
                    Result = new ServiceResult<UserTransactionHistory>
                    {
                        Data = new UserTransactionHistory
                        {
                            TotalResults = userTransactions.Count,
                            Transactions = userTransactions
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private async Task<List<UserTransaction>> GetUserTransactionsAsync(int userId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = @"
                    SELECT TimeStamp, StateName, StateType, OwnType, OperationType, InitialValue, ResultingValue, DeltaValue, DescId, SessionId, ReferenceId, OfferId, ExtendedInfoKey, ExtendedInfoValue
                    FROM TransactionHistory WHERE UserId = @UserId;
                ";

                var transactions = await connection.QueryAsync(query, new { UserId = userId });
                var userTransactions = new List<UserTransaction>();

                foreach (var transaction in transactions)
                {
                    long unixTimeStamp = (long)transaction.TimeStamp;
                    DateTime epochDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    DateTime timestampDateTime = epochDateTime.AddSeconds(unixTimeStamp).ToLocalTime();

                    var userTransaction = new UserTransaction
                    {
                        TransactionItems = new List<UserTransactionItem>
                        {
                            new UserTransactionItem
                            {
                                StateName = (string)transaction.StateName,
                                StateType = (int)transaction.StateType,
                                OwnType = (int)transaction.OwnType,
                                OperationType = (int)transaction.OperationType,
                                InitialValue = (int)transaction.InitialValue,
                                ResultingValue = (int)transaction.ResultingValue,
                                DeltaValue = (int)transaction.DeltaValue,
                                DescId = (int)transaction.DescId
                            }
                        },
                        SessionId = (string)transaction.SessionId,
                        ReferenceId = (string)transaction.ReferenceId,
                        OfferId = (string)transaction.OfferId,
                        Timestamp = timestampDateTime,
                        OperationType = (int)transaction.OperationType,
                        ExtendedInfoItems = new List<ExtendedInfoItem>
                        {
                            new ExtendedInfoItem
                            {
                                Key = (string)transaction.ExtendedInfoKey,
                                Value = (string)transaction.ExtendedInfoValue
                            }
                        }
                    };

                    userTransactions.Add(userTransaction);
                }

                return userTransactions;
            }
        }

        private async Task DeductTransactionTimeAsync(int userId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    var deductQuery = @"
                UPDATE TransactionHistory
                SET ResultingValue = ResultingValue - 5
                WHERE UserId = @UserId AND ResultingValue > 0
                      AND StateName NOT IN ('ranger_kit_offer', 'sniper_kit_offer', 'tactician_kit_offer')
                      AND OfferId NOT IN ('ranger_kit_offer', 'sniper_kit_offer', 'tactician_kit_offer')
                      AND StateName NOT LIKE 'challenge%';
            ";

                    await connection.ExecuteAsync(deductQuery, new { UserId = userId }, transaction);

                    var deleteQuery = @"
                DELETE FROM TransactionHistory
                WHERE UserId = @UserId AND ResultingValue <= 0
                      AND StateName NOT LIKE 'challenge%';
            ";

                    await connection.ExecuteAsync(deleteQuery, new { UserId = userId }, transaction);

                    var findOfferIdQuery = @"
                SELECT OfferId 
                FROM TransactionHistory 
                WHERE UserId = @UserId AND ResultingValue <= 0 
                      AND StateName NOT LIKE 'challenge%'
                ORDER BY TimeStamp DESC 
                LIMIT 1;
            ";

                    var offerId = await connection.ExecuteScalarAsync<string>(findOfferIdQuery, new { UserId = userId }, transaction);

                    if (!string.IsNullOrEmpty(offerId))
                    {
                        var deleteOfferQuery = @"
                    DELETE FROM Transactions
                    WHERE OfferId = @OfferId;
                ";

                        await connection.ExecuteAsync(deleteOfferQuery, new { OfferId = offerId }, transaction);
                    }

                    transaction.Commit();
                }
            }
        }
    }
}