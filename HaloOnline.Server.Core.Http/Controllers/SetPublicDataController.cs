using System;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
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
                var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
                int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

                string connectionString = "Data Source=halodb.sqlite;Version=3;";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        UpsertData(connection, userId, requestData);
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

        private void UpsertData(SQLiteConnection connection, int userId, PublicDataRequest requestData)
        {
            if (requestData == null)
            {
                throw new ArgumentNullException(nameof(requestData));
            }

            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = $"SELECT COUNT(*) FROM PublicData WHERE UserId = @UserId";
                command.Parameters.AddWithValue("@UserId", userId);
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    command.CommandText = $"UPDATE PublicData SET {requestData.ContainerName} = @Data WHERE UserId = @UserId";
                }
                else
                {
                    command.CommandText = $"INSERT INTO PublicData (UserId, {requestData.ContainerName}) VALUES (@UserId, @Data)";
                }

                PropertyInfo property = typeof(PublicDataRequest).GetProperty(requestData.ContainerName);

                command.Parameters.Add(new SQLiteParameter("@Data") { Value = requestData.Data });
                command.ExecuteNonQuery();
            }
        }

        private DbType GetDbType(Type propertyType)
        {
            if (propertyType == typeof(int))
                return DbType.Int32;
            else if (propertyType == typeof(string))
                return DbType.String;
            else if (propertyType == typeof(byte[]))
                return DbType.Binary;
            else if (propertyType == typeof(double))
                return DbType.Double;
            else
                return DbType.Object;
        }
    }

    public class PublicDataRequest
    {
        public string ContainerName { get; set; }
        public object Data { get; set; }
    }
}
