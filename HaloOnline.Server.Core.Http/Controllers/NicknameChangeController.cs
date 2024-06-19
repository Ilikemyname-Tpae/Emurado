using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Core.Repository;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class NicknameChangeController : ApiController
    {
        private readonly string _connectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("NicknameChange")]
        [Authorize]
		// Only made a temporary fix so it doesnt remove the BattleTag when changing name. Will go for a better approach eventually.
        public async Task<IHttpActionResult> NicknameChange([FromBody] Dictionary<string, string> requestBody)
        {
            try
            {
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                if (userId != -1 && requestBody != null && requestBody.TryGetValue("nickname", out var newNickname))
                {
                    UserBaseData existingUserBaseData = null;
                    using (var connection = new SQLiteConnection(_connectionString))
                    {
                        await connection.OpenAsync();
                        using (var command = new SQLiteCommand("SELECT * FROM User WHERE Id = @Id", connection))
                        {
                            command.Parameters.AddWithValue("@Id", userId);

                            using (var reader = await command.ExecuteReaderAsync())
                            {
                                if (await reader.ReadAsync())
                                {
                                    existingUserBaseData = new UserBaseData
                                    {
                                        User = new UserId
                                        {
                                            Id = reader.GetInt32(reader.GetOrdinal("Id"))
                                        },
                                        Nickname = reader.GetString(reader.GetOrdinal("Nickname")),
                                        BattleTag = reader.GetString(reader.GetOrdinal("BattleTag"))
                                    };
                                }
                            }
                        }
                    }

                    if (existingUserBaseData == null)
                    {
                        return NotFound();
                    }

                    existingUserBaseData.Nickname = newNickname;

                    using (var connection = new SQLiteConnection(_connectionString))
                    {
                        await connection.OpenAsync();
                        using (var command = new SQLiteCommand("UPDATE User SET Nickname = @Nickname WHERE Id = @Id", connection))
                        {
                            command.Parameters.AddWithValue("@Nickname", newNickname);
                            command.Parameters.AddWithValue("@Id", userId);
                            await command.ExecuteNonQueryAsync();
                        }
                    }

                    var result = new
                    {
                        NicknameChangeResult = new
                        {
                            retCode = 0
                        }
                    };

                    return Ok(result);
                }
                else
                {
                    return BadRequest(":(");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
