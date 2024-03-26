using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;

namespace AdventureWorks.Client.Blazor.Common
{
    public static class UrlConfig
    {
        public const string ReturnUrlParam = "ReturnUrl";

        public static string GetRedirectUri(this NavigationManager navigation) =>
            QueryHelpers.ParseQuery(new Uri(navigation.Uri).Query).TryGetValue(ReturnUrlParam, out var returnUrl) ? returnUrl[0] : null;

        public const string LoginUrl = "/login";

        public static void NavigateToLogin(this NavigationManager navigation, IDictionary<string, string> query = null)
        {
            var uri = new Uri(navigation.Uri);
            if (uri.AbsolutePath != LoginUrl) // prevent recursive redirects to the login page
            {
                string loginUri = $"{LoginUrl}?{ReturnUrlParam}={WebUtility.UrlEncode(uri.AbsoluteUri)}";
                if (query != null) loginUri = QueryHelpers.AddQueryString(loginUri, query);
                navigation.NavigateTo(loginUri);
            }
            else if (query != null)
                navigation.NavigateTo(QueryHelpers.AddQueryString(uri.AbsoluteUri, query));
        }

        public const string SignInUrl = "/SignIn";
        public const string SignInTicketParam = "ticket";

        public static void NavigateToSignIn(this NavigationManager navigation, string authTicket) =>
            navigation.NavigateTo($"{SignInUrl}?{SignInTicketParam}={authTicket}", true);

        public const string SignOutUrl = "/SignOut";

        public static void NavigateToSignOut(this NavigationManager navigation) =>
            navigation.NavigateTo($"{SignOutUrl}?{ReturnUrlParam}={WebUtility.UrlEncode(navigation.Uri)}", true);

        public const string UnauthorizedUrl = "/unauthorized";
    }
}
