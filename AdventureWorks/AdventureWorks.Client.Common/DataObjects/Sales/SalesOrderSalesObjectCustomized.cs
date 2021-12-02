using AdventureWorks.Services.Common.Enumerations;
using System;

namespace AdventureWorks.Client.Common.DataObjects
{
    public class SalesOrderSalesObjectCustomized : SalesOrderSalesObject
    {
        public SalesOrderSalesObjectCustomized()
        {
        }

        public SalesOrderSalesObjectCustomized(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        // construct properties and child objects
        protected override void Initialize()
        {
            base.Initialize();
            // add custom construction code here
        }

        // perform post initialization
        protected override void OnInitialized()
        {
            base.OnInitialized();
            SalesPersonIdProperty.SetCascadingProperty(SalesPerson.Attributes.TerritoryId, TerritoryIdProperty);
        }
    }
}