using Aot.User.Store.Contracts.Repositories;
using Aot.User.Store.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Aot.User.Store.Repositories
{
    public class UserGroupRoleRepository : IUserGroupRoleRepository
    {
        public async Task<int> CreateAsync(UserGroupRole userGroupRole)
        {
            using var context = new UserStoreDBContext();
            await context.UserGroupRole.AddAsync(userGroupRole);
            return await context.SaveChangesAsync();
        }

        public IEnumerable<UserGroupRole> GetByGroupId(string groupId)
        {
            using var context = new UserStoreDBContext();
            return context.UserGroupRole.Where(x => x.GroupId == groupId);
        }

        public IEnumerable<UserGroupRole> GetByGroupIdUserId(string groupId, string userId)
        {
            using var context = new UserStoreDBContext();
            return context.UserGroupRole.Where(x => x.GroupId == groupId && x.UserId == userId);
        }

        public async Task<int> UpdateAsync(UserGroupRole userGroupRole)
        {
            using var context = new UserStoreDBContext();
            context.UserGroupRole.Update(userGroupRole);
            return await context.SaveChangesAsync();
        }
    }
}
