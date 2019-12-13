using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace SelfieStation.Services
{
    // Handles Authorization for both the AdController and the ImageInfoController.
    public class AuthenticationService
    {
        public void ValidateAuthorizationPrivilege(HttpContext context, string requiredMinimumPrivilege)
        {
            StringValues authToken;
            context.Request.Headers.TryGetValue("Auth", out authToken);

            if (requiredMinimumPrivilege == "admin")
            {
                if (isAdmin(authToken)) { return; }
            }

            // Current privilege not recognized or incorrect.
            throw new UnauthorizedAccessException("Unauthorized access!");
        }

        // Checks if the request token matches the server token.
        public bool isAdmin(string token)
        {
            // Sensitive information, needs to be properly encoded before deployment
            if (token == "644ebb11-2e70-4f94-9b2e-78ca0efaed0c")
            {
                return true;
            }

            return false;
        }
    }
}