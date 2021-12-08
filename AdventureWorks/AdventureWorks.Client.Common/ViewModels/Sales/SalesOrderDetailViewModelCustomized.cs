using System;

namespace AdventureWorks.Client.Common.ViewModels
{
    public class SalesOrderDetailViewModelCustomized : SalesOrderDetailViewModel
    {
        public SalesOrderDetailViewModelCustomized(IServiceProvider sp) : base(sp)
        {
        }

        public override string BaseTitle => GetString("View_Title", MainObj.SalesOrderNumberProperty.Value);
    }
}