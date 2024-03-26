using AdventureWorks.Services.Common.Enumerations;
using System.Collections.Generic;
using System.Security.Claims;
using Xomega.Framework.Client;

namespace AdventureWorks.Services.Common
{
    /// <summary>
    /// Converts UserInfo structure to and from a ClaimsPrincipal.
    /// </summary>
    public class UserInfoPrincipalConverter : IPrincipalConverter<UserInfo>
    {
        public const string ClaimTypeStore = "http://adventure-works.com/store";
        public const string ClaimTypeVendor = "http://adventure-works.com/vendor";
        
        public UserInfo FromPrincipal(ClaimsPrincipal principal)
        {
            var userInfo = new UserInfo
            {
                AuthenticationType = principal.Identity.AuthenticationType,
                UserName = principal.FindFirst(ClaimTypes.Email)?.Value,
                FirstName = principal.FindFirst(ClaimTypes.GivenName)?.Value,
                LastName = principal.FindFirst(ClaimTypes.Surname)?.Value,
                PersonType = principal.FindFirst(ClaimTypes.Role)?.Value,
            };
            if (int.TryParse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
                userInfo.BusinessEntityId = id;
            if (int.TryParse(principal.FindFirst(ClaimTypeStore)?.Value, out int store))
                userInfo.Store = store;
            if (int.TryParse(principal.FindFirst(ClaimTypeVendor)?.Value, out int vendor))
                userInfo.Vendor = vendor;

            return userInfo;
        }

        public ClaimsPrincipal ToPrincipal(UserInfo userInfo)
        {
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier, "" + userInfo.BusinessEntityId, ClaimValueTypes.Integer),
                new Claim(ClaimTypes.Name, userInfo.FirstName + " " + userInfo.LastName),
                new Claim(ClaimTypes.GivenName, userInfo.FirstName),
                new Claim(ClaimTypes.Surname, userInfo.LastName),
                new Claim(ClaimTypes.Email, userInfo.UserName),
                new Claim(ClaimTypes.Role, userInfo.PersonType) // person type is user's role
            };
            if (userInfo.Store != null)
                claims.Add(new Claim(ClaimTypeStore, "" + userInfo.Store.Value, ClaimValueTypes.Integer));
            if (userInfo.Vendor != null)
                claims.Add(new Claim(ClaimTypeVendor, "" + userInfo.Vendor.Value, ClaimValueTypes.Integer));

            return new ClaimsPrincipal(new ClaimsIdentity(claims, userInfo.AuthenticationType));
        }
    }
}
