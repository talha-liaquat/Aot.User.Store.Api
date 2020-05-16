using Aot.User.Store.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aot.User.Store.Contracts.Services
{
    public interface IUserService
    {
        //1. Anyone should be able to sign-up and create groups. Person who created a group is the member admin of the group by default.
        public Task<string> RegisterUserAsync(RegisterUserRequest request);
    }
}
