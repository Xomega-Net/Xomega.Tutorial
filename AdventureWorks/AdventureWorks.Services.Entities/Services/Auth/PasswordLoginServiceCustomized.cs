using AdventureWorks.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Entities
{
    public class PasswordLoginServiceCustomized : PasswordLoginService
    {
        public PasswordLoginServiceCustomized(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        public override async Task<Output<UserInfo>> LoginAsync(PasswordCredentials _credentials, CancellationToken token = default)
        {
            if (_credentials == null)
                currentErrors.AddValidationError(Xomega.Framework.Messages.Validation_Required, nameof(_credentials));
            else
            {
                if (string.IsNullOrEmpty(_credentials?.UserName))
                    currentErrors.AddValidationError(Xomega.Framework.Messages.Validation_Required, nameof(_credentials.UserName));
                if (string.IsNullOrEmpty(_credentials?.Password))
                    currentErrors.AddValidationError(Xomega.Framework.Messages.Validation_Required, nameof(_credentials.Password));
            }

            currentErrors.AbortIfHasErrors(); // abort on empty user name or password

            // lookup password
            var pwdQry = from em in ctx.EmailAddress
                          join pw in ctx.Password on em.BusinessEntityId equals pw.BusinessEntityId
                          where em.EmailAddress1 == _credentials.UserName
                          select pw;
            var pwd = await pwdQry.FirstOrDefaultAsync(token);

            // validate password
            bool passwordValid = false;
            if (pwd != null)
            {
                passwordValid = _credentials.Password == "password"; // for testing only
                // TODO: hash _credentials.Password using pwd.PasswordSalt,
                //       and compare it with pwd.PasswordHash instead
            }

            if (!passwordValid)
                currentErrors.AddValidationError(Messages.InvalidCredentials);

            currentErrors.AbortIfHasErrors();

            // lookup and return user info
            var qry = from ps in ctx.Person
                      join bc in ctx.BusinessEntityContact on ps.BusinessEntityId equals bc.PersonId into bec
                      from bc in bec.DefaultIfEmpty()
                      join st in ctx.Store on bc.BusinessEntityId equals st.BusinessEntityId into store
                      from st in store.DefaultIfEmpty()
                      join vn in ctx.Vendor on bc.BusinessEntityId equals vn.BusinessEntityId into vendor
                      from vn in vendor.DefaultIfEmpty()
                      where ps.BusinessEntityId == pwd.BusinessEntityId
                      select new UserInfo
                      {
                          UserName = _credentials.UserName,
                          BusinessEntityId = ps.BusinessEntityId,
                          PersonType = ps.PersonType,
                          FirstName = ps.FirstName,
                          LastName = ps.LastName,
                          Store = st.BusinessEntityId,
                          Vendor = vn.BusinessEntityId
                      };
            var userInfo = await qry.FirstAsync(token);
            return await Task.FromResult(new Output<UserInfo>(currentErrors, userInfo));
        }
    }
}