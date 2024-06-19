using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HaloOnline.Server.Common.Repositories;
using HaloOnline.Server.Model.Clan;
using HaloOnline.Server.Model.User;

namespace HaloOnline.Server.Core.Repository.Repositories
{
    public class UserBaseDataResponse
    {
        public int retCode { get; set; }
        public List<UserBaseData> data { get; set; }
    }
    public class UserBaseDataRepository : IUserBaseDataRepository
    {
        private readonly IHaloDbContext _context;

        public UserBaseDataRepository(IHaloDbContext context)
        {
            _context = context;
        }

        public Task<UserBaseData> GetByUserIdAsync(int userId)
        {
            var user = _context.Users.Find(userId);

            var responseData = new UserBaseData
            {
                User = user != null
                    ? new UserId { Id = user.Id }
                    : null,
                Nickname = "Welcome!",
                BattleTag = user?.BattleTag,
                Level = 1,
                Clan = user != null
                    ? new ClanId { Id = user.ClanMemberships?.FirstOrDefault()?.ClanId ?? 0 }
                    : null,
                ClanTag = user?.ClanMemberships?.FirstOrDefault()?.Clan?.Tag ?? ""
            };

            return Task.FromResult(responseData);
        }

        public Task<IEnumerable<UserId>> FindUserIdByNicknameAsync(string nicknamePrefix)
        {
            return Task.FromResult(_context.Users
                .Where(u => u.Nickname.StartsWith(nicknamePrefix))
                .Select(u => new UserId
                {
                    Id = u.Id
                })
                .AsEnumerable());
        }
        public async Task<int?> GetUserIdByLoginAsync(string login)
        {
            var user = await _context.Users
                .Where(u => u.Name == login)
                .Select(u => new { u.Id })
                .FirstOrDefaultAsync();

            return user?.Id;
        }

        public Task SetUserBaseDataAsync(UserBaseData userBaseData)
        {
            var user = _context.Users.Find(userBaseData.User.Id);
            if (user == null)
            {
                return Task.FromResult(0);
            }

            user.Nickname = userBaseData.Nickname;
            user.BattleTag = userBaseData.BattleTag;
            user.Level = userBaseData.Level;

            _context.SaveChanges();
            return Task.FromResult(0);
        }
    }
}
