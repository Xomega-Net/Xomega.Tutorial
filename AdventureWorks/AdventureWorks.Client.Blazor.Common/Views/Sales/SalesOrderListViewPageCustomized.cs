using Microsoft.AspNetCore.Authorization;

namespace AdventureWorks.Client.Blazor.Common.Views
{
    [Authorize(Policy = "Sales")]
    public partial class SalesOrderListViewPage
    {
    }
}
