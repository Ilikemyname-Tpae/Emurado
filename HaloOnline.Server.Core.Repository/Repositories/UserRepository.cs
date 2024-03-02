using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Model.User;
using System.Data.SQLite;

namespace HaloOnline.Server.Core.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IHaloDbContext _context;

        public UserRepository(IHaloDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(User user)
        {
            var newUser = new Model.User
            {
                Name = user.UserName,
                PasswordHash = user.UserPasswordHash,
                Gold = 10150,
                Credits = 1000,
                State = 0,
                IsInvitable = 0
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=halodb.sqlite;Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT armor_loadouts, customizations, weapon_loadouts, preferences FROM NewUserPDATA";

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            using (SQLiteCommand insertCommand = connection.CreateCommand())
                            {
                                insertCommand.CommandText = "INSERT INTO PublicData (UserId, armor_loadouts, customizations, weapon_loadouts, preferences) VALUES (@userId, @armor, @customizations, @weapon, @preferences)";
                                insertCommand.Parameters.AddWithValue("@userId", newUser.Id);
                                insertCommand.Parameters.AddWithValue("@armor", reader["armor_loadouts"]);
                                insertCommand.Parameters.AddWithValue("@customizations", reader["customizations"]);
                                insertCommand.Parameters.AddWithValue("@weapon", reader["weapon_loadouts"]);
                                insertCommand.Parameters.AddWithValue("@preferences", reader["preferences"]);

                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }

            user.UserId = newUser.Id;
            return Task.FromResult(0);
        }
        public Task UpdateAsync(User user)
        {
            var foundUser = _context.Users.Find(user.UserId);
            if (foundUser != null)
            {
                foundUser.Name = user.UserName;
                foundUser.PasswordHash = user.UserPasswordHash;
            }
            _context.SaveChanges();
            return Task.FromResult(0);
        }

        public Task DeleteAsync(User user)
        {
            var foundUser = _context.Users.Find(user.UserId);
            if (foundUser != null)
            {
                _context.Users.Remove(foundUser);
            }
            _context.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<User> FindByIdAsync(string userId)
        {
            var foundUser = _context.Users.Find(userId);
            if (foundUser == null) return Task.FromResult<User>(null);
            var result = new User
            {
                UserId = foundUser.Id,
                UserName = foundUser.Name,
                UserPasswordHash = foundUser.PasswordHash
            };
            return Task.FromResult(result);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            var foundUser = _context.Users.FirstOrDefault(u => u.Name == userName);
            if (foundUser == null) return Task.FromResult<User>(null);
            var result = new User
            {
                UserId = foundUser.Id,
                UserName = foundUser.Name,
                UserPasswordHash = foundUser.PasswordHash
            };
            return Task.FromResult(result);
        }

        public Task<int?> GetUserIdByLoginAsync(string login)
        {
            var user = _context.Users
                .Where(u => u.Name == login)
                .Select(u => new { u.Id })
                .FirstOrDefault();

            return Task.FromResult(user?.Id);
        }
    }
}
