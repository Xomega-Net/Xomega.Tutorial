//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Lookup Cache Loaders" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Xomega.Framework.Lookup;

namespace AdventureWorks.Services.Common
{
    public static class LookupCacheLoaders
    {
        public static void AddLookupCacheLoaders(this IServiceCollection container)
        {
            container.AddSingleton<ILookupCacheLoader, SalesPersonReadListCacheLoader>();
            container.AddSingleton<ILookupCacheLoader, SalesTerritoryReadListCacheLoader>();
        }
    }
}