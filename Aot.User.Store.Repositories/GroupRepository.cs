using Aot.User.Store.Contracts.Repositories;
using Aot.User.Store.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Aot.User.Store.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        public async Task<int> CreateAsync(Group group)
        {
            using var context = new UserStoreDBContext();
            await context.Group.AddAsync(group);
            return await context.SaveChangesAsync();
        }

        public IEnumerable<Group> GetByTitle(string title)
        {
            using var context = new UserStoreDBContext();
            return context.Group.Where(x => title.Contains(x.Title, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<int> UpdateAsync(Group group)
        {
            using var context = new UserStoreDBContext();
            context.Group.Update(group);
            return await context.SaveChangesAsync();
        }
    }
}