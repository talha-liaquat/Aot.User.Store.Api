using Aot.User.Store.Contracts.Repositories;
using Aot.User.Store.Contracts.Services;
using Aot.User.Store.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Aot.User.Store.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserGroupRoleRepository _userGroupRoleRepository;
        public GroupService(IGroupRepository groupRepository, IRoleRepository roleRepository, IUserGroupRoleRepository userGroupRoleRepository)
        {
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _userGroupRoleRepository = userGroupRoleRepository ?? throw new ArgumentNullException(nameof(userGroupRoleRepository));
        }
        public async Task<string> CreateGroupAsync(CreateGroupRequest request, string userId)
        {
            var adminRole = _roleRepository.GetAll().Where(x => x.Name == "Admin")?.FirstOrDefault();

            if (adminRole == null)
            {
                adminRole = new Entities.Role { Id = Guid.NewGuid().ToString(), Name = "Admin" };
                await _roleRepository.CreateAsync(adminRole);
            }
            var newGroupId = Guid.NewGuid().ToString();
            await _groupRepository.CreateAsync(new Entities.Group { Id = newGroupId, Title = request.Title });

            var newUserGroupRole = new Entities.UserGroupRole { Id = Guid.NewGuid().ToString(), RoleId = adminRole.Id, UserId = userId, GroupId = newGroupId };
            await _userGroupRoleRepository.CreateAsync(newUserGroupRole);
            
            return newUserGroupRole.Id;
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
