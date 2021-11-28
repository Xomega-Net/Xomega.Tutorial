//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "View Models" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Client.Common.ViewModels
{
    public static class ViewModels
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddTransient<SalesOrderViewModel, SalesOrderViewModelCustomized>();
            services.AddTransient<SalesOrderListViewModel, SalesOrderListViewModel>();
            services.AddTransient<SalesOrderDetailViewModel, SalesOrderDetailViewModel>();
            return services;
        }
    }
}