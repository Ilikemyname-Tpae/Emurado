using System;
using System.Data.SQLite;
using System.IO;
using System.Security.Claims;
using System.Web.Http;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserStorageService.svc")]
    public class SetPublicDataController : ApiController
    {
        [HttpPost]
        [Route("SetPublicData")]
        public IHttpActionResult SetPublicData([FromBody] PublicDataRequest requestData)
        {
            try
            {
                string containerName = requestData.ContainerName;
                byte[] data = requestData.Data;

                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                string connectionString = "Data Source=halodb.sqlite;Version=3;";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        UpsertData(connection, userId, containerName, data);
                    }
                    catch (Exception ex)
                    {
                        return InternalServerError(ex);
                    }
                }

                var response = new
                {
                    SetPublicDataResult = new
                    {
                        retCode = 0,
                        data = true
                    }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error saving data.");
            }
        }

        private void UpsertData(SQLiteConnection connection, int userId, string containerName, byte[] data)
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT COUNT(*) FROM PublicData WHERE UserId = @UserId";
                command.Parameters.AddWithValue("@UserId", userId);
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    command.CommandText = $"UPDATE PublicData SET {containerName} = @Data WHERE UserId = @UserId";
                }
                else
                {
                    command.CommandText = $"INSERT INTO PublicData (UserId, {containerName}) VALUES (@UserId, @Data)";
                }

                command.Parameters.AddWithValue("@Data", data);
                command.ExecuteNonQuery();
            }
        }
    }

    public class PublicDataRequest
    {
        public string ContainerName { get; set; }
        public byte[] Data { get; set; }
    }
}
