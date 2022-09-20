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
    public partial class SalesTerritoryService : BaseService, ISalesTerritoryService
    {
        protected AdventureWorksEntities ctx;

        public SalesTerritoryService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            ctx = serviceProvider.GetService<AdventureWorksEntities>();
        }

        public virtual async Task<Output<ICollection<SalesTerritory_ReadEnumOutput>>> ReadEnumAsync(CancellationToken token = default)
        {
            ICollection<SalesTerritory_ReadEnumOutput> res = null;
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for ReadEnum operation below
                // CUSTOM_CODE_END
                var src = from obj in ctx.SalesTerritory select obj;

                // CUSTOM_CODE_START: add custom filter criteria to the source query for ReadEnum operation below
                // src = src.Where(o => o.FieldName == VALUE);
                // CUSTOM_CODE_END

                var qry = from obj in src
                          select new SalesTerritory_ReadEnumOutput() {
                              TerritoryId = obj.TerritoryId,
                              Name = obj.Name,
                              CountryRegionCode = obj.CountryRegionCode,
                              Group = obj.Group,
                          };

                // CUSTOM_CODE_START: add custom filter criteria to the result query for ReadEnum operation below
                // qry = qry.Where(o => o.FieldName == VALUE);
                // CUSTOM_CODE_END

                currentErrors.AbortIfHasErrors();
                res = await qry.ToListAsync(token);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output<ICollection<SalesTerritory_ReadEnumOutput>>(currentErrors, res));
        }
    }
}