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
    public partial class SpecialOfferProductService : BaseService, ISpecialOfferProductService
    {
        protected AdventureWorksEntities ctx;

        public SpecialOfferProductService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            ctx = serviceProvider.GetService<AdventureWorksEntities>();
        }

        public virtual async Task<Output<ICollection<SpecialOfferProduct_ReadEnumOutput>>> ReadEnumAsync(int _productId, CancellationToken token = default)
        {
            ICollection<SpecialOfferProduct_ReadEnumOutput> res = null;
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for ReadEnum operation below
                // CUSTOM_CODE_END
                var src = from obj in ctx.SpecialOfferProduct select obj;

                // Source filter
                src = AddClause(src, "ProductId", o => o.ProductId, new [] { _productId });

                // CUSTOM_CODE_START: add custom filter criteria to the source query for ReadEnum operation below
                // src = src.Where(o => o.FieldName == VALUE);
                // CUSTOM_CODE_END

                var qry = from obj in src
                          select new SpecialOfferProduct_ReadEnumOutput() {
                              SpecialOfferId = obj.SpecialOfferId,
                              // CUSTOM_CODE_START: set the Description output parameter of ReadEnum operation below
                              Description = obj.SpecialOfferObject.Description, // CUSTOM_CODE_END
                              // CUSTOM_CODE_START: set the Discount output parameter of ReadEnum operation below
                              Discount = obj.SpecialOfferObject.DiscountPct, // CUSTOM_CODE_END
                              // CUSTOM_CODE_START: set the MinQty output parameter of ReadEnum operation below
                              MinQty = obj.SpecialOfferObject.MinQty, // CUSTOM_CODE_END
                              // CUSTOM_CODE_START: set the MaxQty output parameter of ReadEnum operation below
                              MaxQty = obj.SpecialOfferObject.MaxQty, // CUSTOM_CODE_END
                              // CUSTOM_CODE_START: set the Active output parameter of ReadEnum operation below
                              Active = true, // CUSTOM_CODE_END
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
            return await Task.FromResult(new Output<ICollection<SpecialOfferProduct_ReadEnumOutput>>(currentErrors, res));
        }
    }
}