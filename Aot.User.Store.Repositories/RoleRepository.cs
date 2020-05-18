using Aot.User.Store.Contracts.Repositories;
using Aot.User.Store.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aot.User.Store.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public async Task<int> CreateAsync(Role role)
        {
            using var context = new UserStoreDBContext();
            context.Role.Add(role);
            return await context.SaveChangesAsync();
        }

        public IEnumerable<Role> GetAll()
        {
            using var context = new UserStoreDBContext();
            return context.Role;
        }
    }
}