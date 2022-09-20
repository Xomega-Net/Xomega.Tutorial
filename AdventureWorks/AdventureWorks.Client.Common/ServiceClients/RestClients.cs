//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "REST Service Clients" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services.Common
{
    public static class RestClients
    {
        public static IServiceCollection AddRestClients(this IServiceCollection services)
        {
            services.AddScoped<IBusinessEntityService, BusinessEntityServiceClient>();
            services.AddScoped<ICustomerService, CustomerServiceClient>();
            services.AddScoped<IPersonService, PersonServiceClient>();
            services.AddScoped<IProductService, ProductServiceClient>();
            services.AddScoped<IProductSubcategoryService, ProductSubcategoryServiceClient>();
            services.AddScoped<ISalesOrderService, SalesOrderServiceClient>();
            services.AddScoped<ISalesPersonService, SalesPersonServiceClient>();
            services.AddScoped<ISalesReasonService, SalesReasonServiceClient>();
            services.AddScoped<ISalesTerritoryService, SalesTerritoryServiceClient>();
            services.AddScoped<IShipMethodService, ShipMethodServiceClient>();
            services.AddScoped<ISpecialOfferService, SpecialOfferServiceClient>();
            services.AddScoped<ISpecialOfferProductService, SpecialOfferProductServiceClient>();
            return services;
        }
    }
}