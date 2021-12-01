//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Service Implementations" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated
// unless they are placed between corresponding CUSTOM_CODE_START/CUSTOM_CODE_END lines.
//
// This file can be DELETED DURING REGENERATION IF NO LONGER NEEDED, e.g. if it gets renamed.
// To prevent this and preserve manual custom changes please remove the line above.
//---------------------------------------------------------------------------------------------

using AdventureWorks.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework.Services;
// CUSTOM_CODE_START: add namespaces for custom code below
// CUSTOM_CODE_END

namespace AdventureWorks.Services.Entities
{
    public partial class CustomerService : BaseService, ICustomerService
    {
        protected AdventureWorksEntities ctx;

        public CustomerService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            ctx = serviceProvider.GetService<AdventureWorksEntities>();
        }

        public virtual async Task<Output<ICollection<Customer_ReadListOutput>>> ReadListAsync(Customer_ReadListInput_Criteria _criteria, CancellationToken token = default)
        {
            ICollection<Customer_ReadListOutput> res = null;
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for ReadList operation below
                // CUSTOM_CODE_END
                var src = from obj in ctx.Customer select obj;

                // CUSTOM_CODE_START: add custom filter criteria to the source query for ReadList operation below
                // src = src.Where(o => o.FieldName == VALUE);
                // CUSTOM_CODE_END

                var qry = from obj in src
                          select new Customer_ReadListOutput() {
                              CustomerId = obj.CustomerId,
                              PersonId = obj.PersonId,
                              // CUSTOM_CODE_START: set the PersonName output parameter of ReadList operation below
                              PersonName = obj.PersonObject == null ? null :
                                           obj.PersonObject.LastName + ", " +
                                           obj.PersonObject.FirstName, // CUSTOM_CODE_END
                              StoreId = obj.StoreId,
                              // CUSTOM_CODE_START: set the StoreName output parameter of ReadList operation below
                              StoreName = obj.StoreObject.Name, // CUSTOM_CODE_END
                              TerritoryId = obj.TerritoryId,
                              AccountNumber = obj.AccountNumber,
                          };

                // Result filter
                if (_criteria != null)
                {
                    qry = AddClause(qry, "TerritoryId", o => o.TerritoryId, _criteria.TerritoryId);
                    qry = AddClause(qry, "PersonName", o => o.PersonName, _criteria.PersonNameOperator, _criteria.PersonName);
                    qry = AddClause(qry, "StoreName", o => o.StoreName, _criteria.StoreNameOperator, _criteria.StoreName);
                    qry = AddClause(qry, "AccountNumber", o => o.AccountNumber, _criteria.AccountNumberOperator, _criteria.AccountNumber);
                }

                // CUSTOM_CODE_START: add custom filter criteria to the result query for ReadList operation below
                // qry = qry.Where(o => o.FieldName == VALUE);
                // CUSTOM_CODE_END

                currentErrors.AbortIfHasErrors();
                res = await qry.ToListAsync(token);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output<ICollection<Customer_ReadListOutput>>(currentErrors, res));
        }
    }
}