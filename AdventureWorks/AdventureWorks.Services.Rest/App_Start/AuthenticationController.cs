using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Services.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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

        private readonly IPersonService personService;

        public AuthenticationController(ErrorList errorList, ErrorParser errorParser,
            IOptionsMonitor<AuthConfig> configOptions,
            IPersonService personService)
            : base(errorList, errorParser, configOptions)
        {
            this.personService = personService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authentication")]
        public async Task<ActionResult> AuthenticateAsync([FromBody] Credentials credentials, CancellationToken token)
        {
            try
            {
                // TODO: uncomment lines below to validate that user and password are populated
                if (!ModelState.IsValid)
                    currentErrors.AddModelErrors(ModelState);
                currentErrors.AbortIfHasErrors();

                // TODO: validate credentials.UserName and credentials.Password here.
                // Inject services in the controller for that as needed.

                ClaimsIdentity identity = new ClaimsIdentity();
                await personService.AuthenticateAsync(new Common.Credentials()
                {
                    Email = credentials.Username,
                    Password = credentials.Password
                }, token);
                var info = await personService.ReadAsync(credentials.Username, token);
                identity = SecurityManager.CreateIdentity(JwtBearerDefaults.AuthenticationScheme, info.Result);

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
