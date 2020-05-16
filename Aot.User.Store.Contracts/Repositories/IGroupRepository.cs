using Aot.User.Store.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aot.User.Store.Contracts.Repositories
{
    public interface IGroupRepository
    {
        public Task<int> CreateAsync(Group group);
        public IEnumerable<Group> GetByTitle(string title);
        public Task<int> UpdateAsync(Group group);
    }
}
