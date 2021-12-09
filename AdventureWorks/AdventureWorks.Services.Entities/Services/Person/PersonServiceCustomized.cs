using AdventureWorks.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Entities
{
    public class PersonServiceCustomized : PersonService
    {
        public PersonServiceCustomized(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override async Task<Output<PersonInfo>> ReadAsync(string _email, CancellationToken token = default)
        {
            // lookup and return person info
            var qry = from em in ctx.EmailAddress
                      join ps in ctx.Person on em.BusinessEntityId equals ps.BusinessEntityId
                      join bc in ctx.BusinessEntityContact on ps.BusinessEntityId equals bc.PersonId into bec
                      from bc in bec.DefaultIfEmpty()
                      join st in ctx.Store on bc.BusinessEntityId equals st.BusinessEntityId into store
                      from st in store.DefaultIfEmpty()
                      join vn in ctx.Vendor on bc.BusinessEntityId equals vn.BusinessEntityId into vendor
                      from vn in vendor.DefaultIfEmpty()
                      where em.EmailAddress1 == _email
                      select new PersonInfo
                      {
                          BusinessEntityId = ps.BusinessEntityId,
                          PersonType = ps.PersonType,
                          FirstName = ps.FirstName,
                          LastName = ps.LastName,
                          Email = em.EmailAddress1,
                          Store = st.BusinessEntityId,
                          Vendor = vn.BusinessEntityId
                      };
            var person = await qry.FirstOrDefaultAsync(token);
            if (person == null) currentErrors.CriticalError(ErrorType.Data, Messages.PersonNotFound);

            return new Output<PersonInfo>(currentErrors, person);
        }
    }
}