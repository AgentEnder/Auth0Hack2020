using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth0HackBackend.Extensions
{
    public static class IdentityExtensions
    {
        public static string getAuth0Id(this ClaimsPrincipal User)
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
