using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Rest
{
    public class AuthenticationController : TokenAuthController
    {
        public class Credentials
        {
            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }
        }

        public AuthenticationController(ErrorList errorList, ErrorParser errorParser,
            IOptionsMonitor<AuthConfig> configOptions)
            : base(errorList, errorParser, configOptions)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authentication")]
        public async Task<ActionResult> AuthenticateAsync([FromBody] Credentials credentials, CancellationToken token)
        {
            try
            {
                // TODO: uncomment lines below to validate that user and password are populated
                //if (!ModelState.IsValid)
                //    currentErrors.AddModelErrors(ModelState);
                currentErrors.AbortIfHasErrors();

                // TODO: validate credentials.UserName and credentials.Password here.
                // Inject services in the controller for that as needed.
                await Task.CompletedTask;

                string user = string.IsNullOrEmpty(credentials?.Username) ? "Guest" : credentials.Username;

                ClaimsIdentity identity = new ClaimsIdentity();
                // TODO: add claims for the validated user
                identity.AddClaim(new Claim(ClaimTypes.Name, user));

                // generate jwt token
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                string jwtToken = GetSecurityToken(identity, jwtTokenHandler);
                return StatusCode((int)currentErrors.HttpStatus, new Output<string>(currentErrors, jwtToken));
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorsParser.FromException(ex));
            }
            return StatusCode((int)currentErrors.HttpStatus, new Output(currentErrors));
        }
    }
}
