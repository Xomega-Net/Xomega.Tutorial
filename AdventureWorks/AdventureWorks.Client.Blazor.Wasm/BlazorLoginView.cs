using AdventureWorks.Client.Blazor.Common.Views;
using AdventureWorks.Client.Common.DataObjects;
using AdventureWorks.Services.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xomega.Framework.Views;

namespace AdventureWorks.Client.Blazor.Wasm
{
    [AllowAnonymous]
    [Route("/login")]
    public class BlazorLoginView : LoginView
    {
        [Inject] AuthenticationStateProvider authStateProvider { get; set; }

        protected async override Task OnSaveAsync(MouseEventArgs e)
        {
            try
            {
                DetailsViewModel dvm = Model as DetailsViewModel;
                AuthenticationObject authObj = dvm.DetailsObject as AuthenticationObject;
                authObj.Validate(true);
                authObj.GetValidationErrors().AbortIfHasErrors();
                var user = await RestServices.Authenticate(dvm.ServiceProvider,
                    authObj.EmailProperty.Value, authObj.PasswordProperty.Value);
                if (authStateProvider is AuthStateProvider asp)
                    asp.SetCurrentPrincipal(user);

                if (QueryHelpers.ParseQuery(new Uri(Navigation.Uri).Query)
                                .TryGetValue("redirectUri", out var param))
                    Navigation.NavigateTo(param.First());
                else Navigation.NavigateTo("/");
            }
            catch (Exception ex)
            {
                Model.Errors = Model.ErrorParser.FromException(ex);
            }
        }
    }
}