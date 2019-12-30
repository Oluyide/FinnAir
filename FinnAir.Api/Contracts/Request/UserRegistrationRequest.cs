using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinnAir.Api.Contracts.Request
{
    public class UserRegistrationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
