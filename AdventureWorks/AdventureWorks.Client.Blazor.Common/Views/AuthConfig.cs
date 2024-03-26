using Microsoft.AspNetCore.Authorization;
using AdventureWorks.Services.Common;

namespace AdventureWorks.Client.Blazor.Common.Views
{
    public static class AuthConfig
    {
        public static void AddAppPolicies(this AuthorizationOptions opts)
        {
            opts.AddPolicy("Sales", policy => policy.RequireAssertion(ctx =>
                ctx.User.IsEmployee() ||
                ctx.User.IsIndividualCustomer() ||
                ctx.User.IsStoreContact()));
        }
    }
}
