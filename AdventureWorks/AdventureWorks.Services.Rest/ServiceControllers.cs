//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Web API Controllers" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Services.Rest
{
    public static class ServiceControllers
    {
        public static IServiceCollection AddServiceControllers(this IServiceCollection services)
        {
            services.AddScoped<ProductController, ProductController>();
            services.AddScoped<SalesOrderController, SalesOrderController>();
            services.AddScoped<SalesPersonController, SalesPersonController>();
            services.AddScoped<SalesReasonController, SalesReasonController>();
            services.AddScoped<SalesTerritoryController, SalesTerritoryController>();
            services.AddScoped<ShipMethodController, ShipMethodController>();
            services.AddScoped<SpecialOfferController, SpecialOfferController>();
            return services;
        }
    }
}