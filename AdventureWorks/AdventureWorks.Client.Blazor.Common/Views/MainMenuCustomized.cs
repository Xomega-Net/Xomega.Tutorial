using AdventureWorks.Client.Common;
using Xomega.Framework.Blazor.Components;

namespace AdventureWorks.Client.Blazor.Common.Views
{
    public partial class MainMenu
    {
        private partial List<MenuItem> GeneratedItems();

        public List<MenuItem> Items
        {
            get
            {
                var res = GeneratedItems();
                res.Insert(0, new MenuItem()
                {
                    Policy = "",
                    ResourceKey = Messages.HomeView_NavMenu,
                    IconClass = "bi bi-house-door",
                    Href = "/"
                });
                // TODO: add authorization with any security policies
                return res;
            }
        }
    }
}
