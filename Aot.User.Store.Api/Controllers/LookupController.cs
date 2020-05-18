using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aot.User.Store.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        // GET: api/Lookup
        [HttpGet("/roles")]
        public IEnumerable<string> GetRoles()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Lookup
        [HttpGet("/groups")]
        public IEnumerable<string> GetGroups()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
