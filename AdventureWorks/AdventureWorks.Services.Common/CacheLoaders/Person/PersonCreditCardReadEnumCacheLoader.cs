//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Lookup Cache Loaders" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Lookup;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Common
{
    public partial class PersonCreditCardReadEnumCacheLoader : LocalLookupCacheLoader 
    {
        public PersonCreditCardReadEnumCacheLoader(IServiceProvider serviceProvider)
            : base(serviceProvider, true, "person credit card")
        {
        }

        protected virtual async Task<Output<ICollection<PersonCreditCard_ReadEnumOutput>>> CreditCard_ReadEnumAsync(CancellationToken token = default)
        {
            using (var s = serviceProvider.CreateScope())
            {
                object val;
                int _businessEntityId;
                if (Parameters.TryGetValue("business entity id", out val) && val != null)
                    _businessEntityId = (int)val;
                else return null;
                var svc = s.ServiceProvider.GetService<IPersonService>();
                return await svc.CreditCard_ReadEnumAsync(_businessEntityId);
            }
        }

        protected override async Task LoadCacheAsync(string tableType, CacheUpdater updateCache, CancellationToken token = default)
        {
            Dictionary<string, Dictionary<string, Header>> data = new Dictionary<string, Dictionary<string, Header>>();
            var output = await CreditCard_ReadEnumAsync(token);
            if (output?.Messages != null)
                output.Messages.AbortIfHasErrors();
            else if (output?.Result == null) return;

            foreach (var row in output.Result)
            {
                string type = "person credit card";

                if (!data.TryGetValue(type, out Dictionary<string, Header> tbl))
                {
                    data[type] = tbl = new Dictionary<string, Header>();
                }
                string id = "" + row.CreditCardId;
                if (!tbl.TryGetValue(id, out Header h))
                {
                    tbl[id] = h = new Header(type, id, row.Description);
                }
                h.AddToAttribute("person name", row.PersonName);
                h.AddToAttribute("card type", row.CardType);
                h.AddToAttribute("card number", row.CardNumber);
                h.AddToAttribute("exp month", row.ExpMonth);
                h.AddToAttribute("exp year", row.ExpYear);
            }
            // if no data is returned we still need to update cache to mark it as loaded
            if (data.Count == 0) updateCache(new LookupTable(tableType, new List<Header>(), true));
            foreach (string type in data.Keys)
                updateCache(new LookupTable(type, data[type].Values, true));
        }
    }
}