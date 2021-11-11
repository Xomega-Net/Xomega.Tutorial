using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace AdventureWorks.Client.Blazor.Wasm
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal currentPrincipal;

        public AuthStateProvider()
        {
        }

        public void SetCurrentPrincipal(ClaimsPrincipal pricipal)
        {
            currentPrincipal = pricipal;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var principal = currentPrincipal ?? new ClaimsPrincipal(new ClaimsIdentity());
            return Task.FromResult(new AuthenticationState(principal));
        }
    }
}
