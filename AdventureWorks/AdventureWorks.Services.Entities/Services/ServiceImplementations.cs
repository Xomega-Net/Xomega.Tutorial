//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Service Implementations" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using AdventureWorks.Services.Common;

namespace AdventureWorks.Services.Entities
{
    public static class ServiceImplementations
    {
        public static IServiceCollection AddServiceImplementations(this IServiceCollection services)
        {
            services.AddScoped<IBusinessEntityAddressService, BusinessEntityAddressService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IPersonCreditCardService, PersonCreditCardService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductSubcategoryService, ProductSubcategoryService>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();
            services.AddScoped<ISalesPersonService, SalesPersonService>();
            services.AddScoped<ISalesReasonService, SalesReasonService>();
            services.AddScoped<ISalesTerritoryService, SalesTerritoryService>();
            services.AddScoped<IShipMethodService, ShipMethodService>();
            services.AddScoped<ISpecialOfferService, SpecialOfferService>();
            services.AddScoped<ISpecialOfferProductService, SpecialOfferProductService>();
            return services;
        }
    }
}