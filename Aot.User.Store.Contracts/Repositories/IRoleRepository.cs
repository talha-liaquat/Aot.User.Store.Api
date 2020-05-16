using Aot.User.Store.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aot.User.Store.Contracts.Repositories
{
    public interface IRoleRepository
    {
        public IEnumerable<Role> GetAll();
    }
}
