
namespace AdventureWorks.Client.Blazor.Common.Views
{
    public partial class LoginView
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Visible = true;
            ActivateFromQuery = true;
        }
    }
}