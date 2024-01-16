using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Web.Http;
using System.Linq;
using System.Security.Claims;

namespace HaloOnline.Server.Core.Http.Controllers
{
    public class UserState
    {
        public int OwnType { get; set; }
        public int Value { get; set; }
        public string StateName { get; set; }
        public int StateType { get; set; }
    }

    [RoutePrefix("UserService.svc")]
    public class GetUserStatesController : ApiController
    {
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("GetUserStates")]
        [Authorize]
        public IHttpActionResult GetUserStates()
        {
            var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
            int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

            var userStateList = new List<UserState>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var existingStates = GetUserStateNames(userId, connection);

                var statesToAdd = new List<UserState>
                  {
                    new UserState { OwnType = 1, Value = 1, StateName = "ranger_default_kit", StateType = 4 },
                    new UserState { OwnType = 0, Value = 0, StateName = "class_select_token", StateType = 12 },
                    new UserState { OwnType = 1, Value = 1, StateName = "account_rename_token", StateType = 12 },
                    new UserState { OwnType = 0, Value = 1000, StateName = "Credits", StateType = 2 },
                    new UserState { OwnType = 0, Value = 10150, StateName = "Gold", StateType = 3 },
                    new UserState { OwnType = 0, Value = 1, StateName = "armor_loadout_0", StateType = 0 },
                    new UserState { OwnType = 0, Value = 1, StateName = "weapon_loadout_0", StateType = 0 },
                    new UserState { OwnType = 1, Value = 1, StateName = "assault_rifle", StateType = 4 },
                    new UserState { OwnType = 1, Value = 1, StateName = "battle_rifle", StateType = 4 },
                    new UserState { OwnType = 1, Value = 1, StateName = "smg", StateType = 4 },
                    new UserState { OwnType = 1, Value = 1, StateName = "dmr", StateType = 4 },
                    new UserState { OwnType = 1, Value = 1, StateName = "frag_grenade", StateType = 4 },
                    new UserState { OwnType = 1, Value = 1, StateName = "magnum", StateType = 4 },
                 };

                foreach (var stateToAdd in statesToAdd)
                {
                    if (!existingStates.Contains(stateToAdd.StateName))
                    {
                        AddStateToUser(userId, stateToAdd, connection);
                    }
                }

                userStateList = GetUserStatesFromDatabase(userId, connection);

                connection.Close();
            }

            var timestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);

            var response = new
            {
                GetUserStatesResult = new
                {
                    retCode = 0,
                    data = new
                    {
                        UserStateList = userStateList,
                        TimeStamp = timestamp,
                        User = new { Id = userId },
                        Nickname = ""
                    }
                }
            };

            return Ok(response);
        }

        private List<string> GetUserStateNames(int userId, SQLiteConnection connection)
        {
            var existingStates = new List<string>();

            using (var command = new SQLiteCommand($"SELECT StateName FROM UserStates WHERE UserId = {userId}", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        existingStates.Add(reader["StateName"].ToString());
                    }
                }
            }

            return existingStates;
        }

        private void AddStateToUser(int userId, UserState stateToAdd, SQLiteConnection connection)
        {
            if (IsStateAlreadyExists(userId, stateToAdd.StateName, stateToAdd.Value, stateToAdd.StateType, connection))
            {
                return;
            }

            using (var command = new SQLiteCommand("INSERT INTO UserStates (UserId, OwnType, Value, StateName, StateType) VALUES (@UserId, @OwnType, @Value, @StateName, @StateType)", connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@OwnType", stateToAdd.OwnType);
                command.Parameters.AddWithValue("@Value", stateToAdd.Value);
                command.Parameters.AddWithValue("@StateName", stateToAdd.StateName);
                command.Parameters.AddWithValue("@StateType", stateToAdd.StateType);

                command.ExecuteNonQuery();
            }
        }

        private bool IsStateAlreadyExists(int userId, string stateName, int value, int stateType, SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand($"SELECT COUNT(*) FROM UserStates WHERE UserId = {userId} AND StateName = @StateName AND Value = @Value AND StateType = @StateType", connection))
            {
                command.Parameters.AddWithValue("@StateName", stateName);
                command.Parameters.AddWithValue("@Value", value);
                command.Parameters.AddWithValue("@StateType", stateType);

                var count = (long)command.ExecuteScalar();

                return count > 0;
            }
        }

        private List<UserState> GetUserStatesFromDatabase(int userId, SQLiteConnection connection)
        {
            var userStateList = new List<UserState>();

            using (var command = new SQLiteCommand($"SELECT * FROM UserStates WHERE UserId = {userId}", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var userState = new UserState
                        {
                            OwnType = Convert.ToInt32(reader["OwnType"]),
                            Value = Convert.ToInt32(reader["Value"]),
                            StateName = reader["StateName"].ToString(),
                            StateType = Convert.ToInt32(reader["StateType"])
                        };

                        userStateList.Add(userState);
                    }
                }
            }

            return userStateList;
        }
    }
}
