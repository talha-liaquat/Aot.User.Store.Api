using Aot.User.Store.Contracts.Services;
using Aot.User.Store.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aot.User.Store.Services
{
    public class GroupService : IGroupService
    {
        public Task<string> CreateGroupAsync(CreateGroupRequest request, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetGroupUsers(string groupId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetGroupUsers(string groupId, string title, string adminUserId)
        {
            throw new NotImplementedException();
        }

        public bool JoinGroup(string userId, string groupid)
        {
            throw new NotImplementedException();
        }

        public bool RemoveGroup(string userId, string groupId)
        {
            throw new NotImplementedException();
        }

        public Task<string> RemoveUserGroup(string groupId, string userId, string adminUerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupSearchResult> Search(string title)
        {
            throw new NotImplementedException();
        }
    }
}
