using HaloOnline.Server.Core.Http.Model.User;
using System;
using System.Data.SQLite;
using System.Linq;
using System.Web.Http;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class GetUsersByNicknameController : ApiController
    {
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("GetUsersByNickname")]
        public IHttpActionResult GetUsersByNickname([FromBody] GetUsersByNicknameRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.NicknamePrefix))
            {
                return BadRequest("Invalid request");
            }

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT Id FROM User WHERE UPPER(Nickname) = UPPER(@Nickname)";
                    command.Parameters.AddWithValue("@Nickname", request.NicknamePrefix);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var userId = reader["Id"];

                            var result = new
                            {
                                GetUsersByNicknameResult = new
                                {
                                    retCode = 0,
                                    data = new[]
                                    {
                                        new
                                        {
                                            Id = userId
                                        }
                                    }
                                }
                            };

                            return Ok(result);
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                }
            }
        }
    }
}
