using System;
using System.Collections.Generic;
using Aot.User.Store.Dtos;
using System.Text;
using System.Threading.Tasks;

namespace Aot.User.Store.Contracts.Services
{
    public interface IGroupService
    {
        //2. Any logged in user can search, select and join any group.
        public IEnumerable<GroupSearchResult> Search(string title);
        public bool JoinGroup(string userId, string groupid);
        public bool RemoveGroup(string userId, string groupId);
        //1. Anyone should be able to sign-up and create groups. Person who created a group is the member admin of the group by default.
        public Task<string> CreateGroupAsync(CreateGroupRequest request, string userId);
        //3. Only the admin of the group should be able to list and view the group members.
        public Task<string> GetGroupUsers(string groupId, string userId);
        //4. Admin should be able to remove members from the group.
        public Task<string> RemoveUserGroup(string groupId, string userId, string adminUerId);
        //5. Admin should be able to change the name of the group at any time.
        public Task<string> GetGroupUsers(string groupId, string title, string adminUserId);
    }
}