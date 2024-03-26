using AdventureWorks.Services.Common.Enumerations;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace AdventureWorks.Services.Common
{
    public static class PrincipalExtensions
    {
        public static bool IsStoreContact(this IPrincipal principal) =>
            principal.IsInRole(PersonType.StoreContact);

        public static bool IsIndividualCustomer(this IPrincipal principal) =>
            principal.IsInRole(PersonType.IndividualCustomer);

        public static bool IsSalesPerson(this IPrincipal principal) =>
            principal.IsInRole(PersonType.SalesPerson);

        public static bool IsEmployee(this IPrincipal principal) =>
            principal.IsSalesPerson() || principal.IsInRole(PersonType.Employee);

        public static int? GetStoreId(this IPrincipal principal)
        {
            Claim storeIdClaim = null;
            if (principal.Identity is ClaimsIdentity ci && (storeIdClaim = 
                ci.Claims.FirstOrDefault(c => c.Type == UserInfoPrincipalConverter.ClaimTypeStore)) != null)
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