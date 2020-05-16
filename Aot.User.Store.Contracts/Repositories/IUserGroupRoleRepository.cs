using Aot.User.Store.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aot.User.Store.Contracts.Repositories
{
    public interface IUserGroupRoleRepository
    {
        public Task<int> CreateAsync(UserGroupRole userGroupRole);
        public Task<int> UpdateAsync(UserGroupRole userGroupRole);
        public IEnumerable<UserGroupRole> GetByGroupId(string groupId);
        public IEnumerable<UserGroupRole> GetByGroupIdUserId(string groupId, string userId);
    }
}
