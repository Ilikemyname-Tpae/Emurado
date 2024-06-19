using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Dapper;

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
        public async Task<IHttpActionResult> GetUserStates()
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                var userStateList = await GetUserStatesFromDatabaseAsync(userId);

                var timestamp = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

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
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private async Task<List<UserState>> GetUserStatesFromDatabaseAsync(int userId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                await connection.OpenAsync();
                var existingStates = await GetUserStateNamesAsync(userId, connection);

                var statesToAdd = new List<UserState>
                {
                    new UserState { OwnType = 1, Value = 1, StateName = "helmet_air_assault", StateType = 4 },
                    new UserState { OwnType = 1, Value = 1, StateName = "chest_air_assault", StateType = 4 },
                    new UserState { OwnType = 1, Value = 1, StateName = "shoulders_air_assault", StateType = 4 },
                    new UserState { OwnType = 1, Value = 1, StateName = "arms_air_assault", StateType = 4 },
                    new UserState { OwnType = 1, Value = 1, StateName = "legs_air_assault", StateType = 4 },
                    new UserState { OwnType = 0, Value = 0, StateName = "clan_create_token", StateType = 12 },
                    new UserState { OwnType = 1, Value = 1, StateName = "class_select_token", StateType = 12 },
                    new UserState { OwnType = 3, Value = 3, StateName = "account_rename_token", StateType = 12 },
                    new UserState { OwnType = 0, Value = 1, StateName = "Level", StateType = 9 },
                    new UserState { OwnType = 0, Value = 0, StateName = "Level_Progress", StateType = 1 },
                    new UserState { OwnType = 0, Value = 1000, StateName = "Credits", StateType = 2 },
                    new UserState { OwnType = 0, Value = 10150, StateName = "Gold", StateType = 3 },
                    new UserState { OwnType = 0, Value = 1, StateName = "armor_loadout_0", StateType = 0 },
                    new UserState { OwnType = 0, Value = 1, StateName = "weapon_loadout_0", StateType = 0 },
                    new UserState { OwnType = 1, Value = 1, StateName = "assault_rifle", StateType = 4 },
                    new UserState { OwnType = 1, Value = 1, StateName = "smg", StateType = 4 },
                    new UserState { OwnType = 1, Value = 1, StateName = "dmr", StateType = 4 },
                    new UserState { OwnType = 1, Value = 1, StateName = "frag_grenade", StateType = 4 },
                    new UserState { OwnType = 1, Value = 1, StateName = "magnum", StateType = 4 },
                };

                foreach (var stateToAdd in statesToAdd)
                {
                    if (!existingStates.Contains(stateToAdd.StateName))
                    {
                        await AddStateToUserAsync(userId, stateToAdd, connection);
                    }
                }

                return await GetUserStatesFromDatabaseInternalAsync(userId, connection);
            }
        }

        private async Task<List<string>> GetUserStateNamesAsync(int userId, SQLiteConnection connection)
        {
            var query = "SELECT StateName FROM UserStates WHERE UserId = @UserId";
            var existingStates = await connection.QueryAsync<string>(query, new { UserId = userId });
            return existingStates.AsList();
        }

        private async Task AddStateToUserAsync(int userId, UserState stateToAdd, SQLiteConnection connection)
        {
            if (await IsStateAlreadyExistsAsync(userId, stateToAdd.StateName, stateToAdd.Value, stateToAdd.StateType, connection))
            {
                return;
            }

            var query = "INSERT INTO UserStates (UserId, OwnType, Value, StateName, StateType) VALUES (@UserId, @OwnType, @Value, @StateName, @StateType)";
            await connection.ExecuteAsync(query, new
            {
                UserId = userId,
                OwnType = stateToAdd.OwnType,
                Value = stateToAdd.Value,
                StateName = stateToAdd.StateName,
                StateType = stateToAdd.StateType
            });
        }

        private async Task<bool> IsStateAlreadyExistsAsync(int userId, string stateName, int value, int stateType, SQLiteConnection connection)
        {
            var query = "SELECT COUNT(*) FROM UserStates WHERE UserId = @UserId AND StateName = @StateName AND Value = @Value AND StateType = @StateType";
            var count = await connection.ExecuteScalarAsync<long>(query, new
            {
                UserId = userId,
                StateName = stateName,
                Value = value,
                StateType = stateType
            });

            return count > 0;
        }

        private async Task<List<UserState>> GetUserStatesFromDatabaseInternalAsync(int userId, SQLiteConnection connection)
        {
            var query = "SELECT OwnType, Value, StateName, StateType FROM UserStates WHERE UserId = @UserId";
            var userStateList = await connection.QueryAsync<UserState>(query, new { UserId = userId });
            return userStateList.AsList();
        }
    }
}
