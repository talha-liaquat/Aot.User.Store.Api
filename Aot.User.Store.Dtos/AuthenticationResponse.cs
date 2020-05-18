using System;
using System.Collections.Generic;
using System.Text;

namespace Aot.User.Store.Dtos
{
    public class AuthenticationResponse
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}