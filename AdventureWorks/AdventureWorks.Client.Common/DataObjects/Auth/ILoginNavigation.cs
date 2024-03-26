using AdventureWorks.Services.Common;

namespace AdventureWorks.Client.Common.DataObjects
{
    /// <summary>
    /// Service for navigating to other screens on login as necessary.
    /// </summary>
    public interface ILoginNavigation
    {
        void NavigateOnLogin(UserInfo userInfo);
    }
}