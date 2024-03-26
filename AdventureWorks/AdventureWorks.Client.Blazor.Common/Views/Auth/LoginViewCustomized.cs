using AdventureWorks.Client.Common.DataObjects;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Client.Blazor.Common.Views
{
    [Route(UrlConfig.LoginUrl)]
    public partial class LoginView
    {
        [Inject] IServiceProvider ServiceProvider { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            Visible = true; // manually make it visible, as there is no separate page that does that.

            await base.OnParametersSetAsync();

            // set login navigation directly to make sure navigation manager is initialized.
            if (VM.MainObj is LoginObjectCustomized authObj)
            {
                authObj.LoginNavigation = ServiceProvider.GetService<ILoginNavigation>();
            }
        }
    }
}