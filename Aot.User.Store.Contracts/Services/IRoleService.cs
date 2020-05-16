using Aot.User.Store.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aot.User.Store.Contracts.Services
{
    public interface IRoleService
    {
        public IEnumerable<RoleResponse> GetAll();
    }
}