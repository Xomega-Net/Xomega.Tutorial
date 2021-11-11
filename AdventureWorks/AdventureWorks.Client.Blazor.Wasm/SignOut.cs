using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using Xomega.Framework.Blazor.Views;

namespace AdventureWorks.Client.Blazor.Wasm
{
    [Route("SignOut")]
    public class SignOut : BlazorView
    {
        [Inject] AuthenticationStateProvider authStateProvider { get; set; }
        [Inject] HttpClient httpClient { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (authStateProvider is AuthStateProvider asp)
            {
                asp.SetCurrentPrincipal(new ClaimsPrincipal(new ClaimsIdentity()));
                httpClient.DefaultRequestHeaders.Remove("Authorization");

                if (QueryHelpers.ParseQuery(new Uri(Navigation.Uri).Query).TryGetValue("redirectUri", out var param))
                    Navigation.NavigateTo(param.First());
                else Navigation.NavigateTo($"/login");
            }
        }
    }
}
