using Aot.User.Store.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aot.User.Store.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<int> CreateAsync(Entities.User user)
        {
            using var context = new UserStoreDBContext();
            await context.User.AddAsync(user);
            return await context.SaveChangesAsync();
        }
    }
}
