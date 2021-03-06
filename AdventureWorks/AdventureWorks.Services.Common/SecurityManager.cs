using AdventureWorks.Services.Common.Enumerations;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace AdventureWorks.Services.Common
{
    public static class SecurityManager
    {
        public const string ClaimTypeStore = "http://adventure-works.com/store";
        public const string ClaimTypeVendor = "http://adventure-works.com/vendor";

        public static ClaimsIdentity CreateIdentity(string authenticationType, PersonInfo userInfo)
        {
            if (userInfo == null) return null; // not authenticated

            ClaimsIdentity ci = new ClaimsIdentity(authenticationType);
            ci.AddClaim(new Claim(ClaimTypes.NameIdentifier, "" + userInfo.BusinessEntityId, ClaimValueTypes.Integer));
            ci.AddClaim(new Claim(ClaimTypes.Name, userInfo.FirstName + " " + userInfo.LastName));
            ci.AddClaim(new Claim(ClaimTypes.GivenName, userInfo.FirstName));
            ci.AddClaim(new Claim(ClaimTypes.Surname, userInfo.LastName));
            ci.AddClaim(new Claim(ClaimTypes.Email, userInfo.Email));
            ci.AddClaim(new Claim(ClaimTypes.Role, userInfo.PersonType)); // person type is user's role
            if (userInfo.Store != null)
                ci.AddClaim(new Claim(ClaimTypeStore, "" + userInfo.Store.Value, ClaimValueTypes.Integer));
            if (userInfo.Vendor != null)
                ci.AddClaim(new Claim(ClaimTypeVendor, "" + userInfo.Vendor.Value, ClaimValueTypes.Integer));
            return ci;
        }

        public static bool IsStoreContact(this IPrincipal principal)
        {
            return principal.IsInRole(PersonType.StoreContact);
        }

        public static bool IsIndividualCustomer(this IPrincipal principal)
        {
            return principal.IsInRole(PersonType.IndividualCustomer);
        }

        public static bool IsSalesPerson(this IPrincipal principal)
        {
            return principal.IsInRole(PersonType.SalesPerson);
        }

        public static bool IsEmployee(this IPrincipal principal)
        {
            return principal.IsSalesPerson() || principal.IsInRole(PersonType.Employee);
        }

        public static int? GetStoreId(this IPrincipal principal)
        {
            Claim storeIdClaim = null;
            if (principal.Identity is ClaimsIdentity ci &&
                (storeIdClaim = ci.Claims.FirstOrDefault(c => c.Type == ClaimTypeStore)) != null)
                return int.Parse(storeIdClaim.Value);
            return null;
        }

        public static int? GetPersonId(this IPrincipal principal)
        {
            Claim idClaim = null;
            if (principal.Identity is ClaimsIdentity ci &&
                (idClaim = ci.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)) != null)
                return int.Parse(idClaim.Value);
            return null;
        }
    }
}
