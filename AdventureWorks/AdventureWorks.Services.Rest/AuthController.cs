using AdventureWorks.Services.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Xomega.Framework;
using Xomega.Framework.Client;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Rest
{
    [ApiController]
    [AllowAnonymous]
    [Route("auth")]
    public class AuthController(IPasswordLoginService loginService, IPrincipalConverter<UserInfo> principalConverter,
        ErrorList errorList, ErrorParser errorParser) : BaseController(errorList, errorParser)
    {
        [HttpPost]
        [Route("cookie")]
        public async Task<ActionResult> AuthCookieAsync([FromBody] PasswordCredentials credentials, CancellationToken token)
        {
            try
            {
                if (!ModelState.IsValid)
                    currentErrors.AddModelErrors(ModelState);
                currentErrors.AbortIfHasErrors();

                var res = await loginService.LoginAsync(credentials, token);
                UserInfo userInfo = res.Result;
                userInfo.AuthenticationType = CookieAuthenticationDefaults.AuthenticationScheme;

                var principal = principalConverter.ToPrincipal(userInfo);
                await HttpContext.SignInAsync(principal);
                return StatusCode((int)currentErrors.HttpStatus, new Output<UserInfo>(currentErrors, userInfo));
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorsParser.FromException(ex));
            }
            return StatusCode((int)currentErrors.HttpStatus, new Output(currentErrors));
        }
    }
}
