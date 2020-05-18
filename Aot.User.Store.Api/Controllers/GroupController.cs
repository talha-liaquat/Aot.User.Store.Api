using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Aot.User.Store.Contracts.Services;
using Aot.User.Store.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Aot.User.Store.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private byte[] SecurityKey { get { return Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]); } }

        private readonly IGroupService _groupService;
        private readonly IConfiguration _configuration;
        public GroupController(IGroupService groupService, IConfiguration configuration)
        {
            _groupService = groupService ?? throw new ArgumentNullException(nameof(groupService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateGroupAsync([FromBody]CreateGroupRequest request)
        {
            var id = await _groupService.CreateGroupAsync(request, UserId(Request.Headers["Authorization"]));

            return Ok(id);
        }

        private string UserId(string token)
        {
            token = token.Replace("Bearer ", string.Empty);
            var principal = GetPrincipalFromExpiredToken(token);
            return principal?.FindFirst("user-id")?.Value;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(SecurityKey),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }
}