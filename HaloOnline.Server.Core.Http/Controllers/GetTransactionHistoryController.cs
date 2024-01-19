using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Model;
using HaloOnline.Server.Core.Http.Model.User;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class GetTransactionHistoryController : ApiController
    {
        private readonly string connectionString = "Data Source=halodb.sqlite";
        private bool stopUpdateThread = false;

        public GetTransactionHistoryController()
        {
            Thread.Sleep(5000);
            Thread updateThread = new Thread(AutoUpdateTransactionHistory);
            updateThread.Start();
        }

        [HttpPost]
        [Route("GetTransactionHistory")]
        public IHttpActionResult GetTransactionHistory()
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                List<UserTransaction> userTransactions = new List<UserTransaction>();

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand("SELECT * FROM TransactionHistory WHERE UserId = @UserId", connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                long unixTimeStamp = Convert.ToInt64(reader["TimeStamp"]);
                                DateTime epochDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                                DateTime timestampDateTime = epochDateTime.AddSeconds(unixTimeStamp).ToLocalTime();

                                UserTransaction userTransaction = new UserTransaction
                                {
                                    TransactionItems = new List<UserTransactionItem>
                                    {
                                        new UserTransactionItem
                                        {
                                            StateName = reader["StateName"].ToString(),
                                            StateType = Convert.ToInt32(reader["StateType"]),
                                            OwnType = Convert.ToInt32(reader["OwnType"]),
                                            OperationType = Convert.ToInt32(reader["OperationType"]),
                                            InitialValue = Convert.ToInt32(reader["InitialValue"]),
                                            ResultingValue = Convert.ToInt32(reader["ResultingValue"]),
                                            DeltaValue = Convert.ToInt32(reader["DeltaValue"]),
                                            DescId = Convert.ToInt32(reader["DescId"])
                                        }
                                    },
                                    SessionId = reader["SessionId"].ToString(),
                                    ReferenceId = reader["ReferenceId"].ToString(),
                                    OfferId = reader["OfferId"].ToString(),
                                    Timestamp = timestampDateTime,
                                    OperationType = Convert.ToInt32(reader["OperationType"]),
                                    ExtendedInfoItems = new List<ExtendedInfoItem>
                                    {
                                        new ExtendedInfoItem
                                        {
                                            Key = reader["ExtendedInfoKey"].ToString(),
                                            Value = reader["ExtendedInfoValue"].ToString()
                                        }
                                    }
                                };

                                userTransactions.Add(userTransaction);
                            }
                        }
                    }
                }

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

        private void AutoUpdateTransactionHistory()
        {
            while (!stopUpdateThread)
            {
                try
                {
                    using (var connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        using (var updateCommand = new SQLiteCommand("UPDATE TransactionHistory SET ResultingValue = ResultingValue - 5", connection))
                        {
                            updateCommand.ExecuteNonQuery();
                        }

                        using (var deleteCommand = new SQLiteCommand("DELETE FROM TransactionHistory WHERE ResultingValue <= 0", connection))
                        {
                            deleteCommand.ExecuteNonQuery();
                        }

                        using (var checkCommand = new SQLiteCommand("SELECT COUNT(*) FROM TransactionHistory", connection))
                        {
                            int rowCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                            if (rowCount == 0)
                            {
                                stopUpdateThread = true;
                                Console.WriteLine("Auto-update stopped: No rows remaining in TransactionHistory.");
                                return;
                            }
                        }
                    }

                    Thread.Sleep(5000);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
