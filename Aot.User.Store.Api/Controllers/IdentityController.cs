using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aot.User.Store.Contracts.Services;
using Aot.User.Store.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Aot.User.Store.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IUserService _userService;

        public IdentityController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(LoginRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public IActionResult AuthenticateAsync([FromBody]LoginRequest request)
        {
            var auth = _userService.Authenticate(request);

            if (auth == null)
                return Unauthorized();

            return Ok(new AuthenticationResponse { Token = auth.Value.token, UserId = auth.Value.userId });
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(RegisterUserRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUserRequestAsync([FromBody]RegisterUserRequest request)
        {
            var token = await _userService.RegisterUserAsync(request);

            return Ok(token);
        }
    }
}