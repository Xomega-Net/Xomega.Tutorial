using Microsoft.AspNetCore.Mvc;
using Xomega.Framework.Services;
using static AdventureWorks.Client.Blazor.Common.UrlConfig;

namespace AdventureWorks.Client.Blazor
{
    public static class SignInEndpoints
    {
        /// <summary>
        /// Adds an endpoint that allows signing in with the provided authentication ticket.
        /// The endpoint redirects to the URL specified in the ticket.
        /// </summary>
        /// <param name="endpoints">Endpoint builder to add the sign in endpoint to.</param>
        public static void AddSignIn(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet(SignInUrl, async Task ([FromQuery(Name = SignInTicketParam)] string ticket,
                    [FromServices] SignInManager signInMgr) =>
            {
                await signInMgr.SignInAsync(ticket);
            });
        }

        /// <summary>
        /// Adds an endpoint that allows signing out.
        /// The endpoint redirects to the URL specified in the query parameter.
        /// </summary>
        /// <param name="endpoints">Endpoint builder to add the sign out endpoint to.</param>
        public static void AddSignOut(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet(SignOutUrl, async Task ([FromQuery(Name = ReturnUrlParam)] string redirectUri,
                    [FromServices] SignInManager signInMgr) =>
            {
                await signInMgr.SignOutAsync(redirectUri);
            });
        }
    }
}