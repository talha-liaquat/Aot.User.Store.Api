using Aot.User.Store.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

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

        public Entities.User GetUser(string username, string password)
        {
            using var context = new UserStoreDBContext();
            return context.User.SingleOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == password);
        }
    }
}
