using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aot.User.Store.Contracts.Repositories
{
    public interface IUserRepository
    {
        public Task<int> CreateAsync(Entities.User user);
    }
}
