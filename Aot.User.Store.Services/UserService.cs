using Aot.User.Store.Contracts;
using Aot.User.Store.Contracts.Repositories;
using Aot.User.Store.Contracts.Services;
using Aot.User.Store.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aot.User.Store.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public async Task<string> RegisterUserAsync(RegisterUserRequest request)
        {
            var newUserId = Guid.NewGuid().ToString();

            var rowsEffected = await _userRepository.CreateAsync(new Entities.User { 
                Id = newUserId,
                CreateOn = DateTime.UtcNow,
                IsActive = true,
                Name = request.Name                
            });

            if (rowsEffected != 1)
                throw new InsertFailedException($"Error saving userId");

            return newUserId;
        }
    }
}
