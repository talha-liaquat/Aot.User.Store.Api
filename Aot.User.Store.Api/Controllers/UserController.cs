using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aot.User.Store.Contracts.Services;
using Aot.User.Store.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aot.User.Store.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUserRequest request)
        {
            var registeredUser = await _userService.RegisterUserAsync(request);
            return Ok(registeredUser);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
