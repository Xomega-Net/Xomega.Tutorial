using AdventureWorks.Client.Blazor.Common;
using AdventureWorks.Client.Common.DataObjects;
using AdventureWorks.Services.Common;
using Microsoft.AspNetCore.Components;

namespace AdventureWorks.Client.Blazor.Wasm
{
    /// <summary>
    /// Navigates to the redirect URI after the login.
    /// </summary>
    public class WasmLoginNavigation(NavigationManager navigation) : ILoginNavigation
    {
        public void NavigateOnLogin(UserInfo userInfo)
        {
            navigation.NavigateTo(navigation.GetRedirectUri());
        }
    }
}
