using AdventureWorks.Client.Blazor.Common;
using AdventureWorks.Client.Common.DataObjects;
using AdventureWorks.Services.Common;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Xomega.Framework.Client;
using Xomega.Framework.Services;

namespace AdventureWorks.Client.Blazor
{
    /// <summary>
    /// Creates an authentication ticket and passes it to the SignIn endpoint, in order to set the cookie outside of the SignalR circuit.
    /// </summary>
    public class ServerLoginNavigation(NavigationManager navigation, IPrincipalConverter<UserInfo> principalConverter,
        SignInManager signInMgr) : ILoginNavigation
    {
        public void NavigateOnLogin(UserInfo userInfo)
        {
            userInfo.AuthenticationType = CookieAuthenticationDefaults.AuthenticationScheme;
            var principal = principalConverter.ToPrincipal(userInfo);
            string authTicket = signInMgr.GetSignInTicket(principal, navigation.GetRedirectUri());
            navigation.NavigateToSignIn(authTicket);
        }
    }
}
