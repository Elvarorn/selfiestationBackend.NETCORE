using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace SelfieStation.Services
{
    public class AuthenticationService
    {
        public void ValidateAuthorizationPrivilege(HttpContext context, string requiredMinimumPrivilege)
        {
            StringValues authToken;
            context.Request.Headers.TryGetValue("Authorization", out authToken);

            if (requiredMinimumPrivilege == "auth")
            {
                //Do nothing, correct privilege established
                if (isAuth(authToken) || isAdmin(authToken)) { return; }
            }
            else if (requiredMinimumPrivilege == "admin")
            {
                //Do nothing, correct privilege established
                if (isAdmin(authToken)) { return; }
            }

            //Current privilege not recognized or incorrect
            throw new UnauthorizedAccessException("Unauthorized access!");
        }


        public bool isAuth(string token)
        {
            if (token == "auth")
            {
                return true;
            }

            return false;
        }

        public bool isAdmin(string token)
        {
            if (token == "admin")
            {
                return true;
            }

            return false;
        }
    }
}