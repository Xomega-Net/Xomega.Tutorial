using AdventureWorks.Services.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework.Services;

namespace AdventureWorks.Client.Common.DataObjects
{
    public class LoginObjectCustomized : LoginObject
    {
        public LoginObjectCustomized()
        {
        }

        public LoginObjectCustomized(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        // construct properties and child objects
        protected override void Initialize()
        {
            base.Initialize();

            // disable modification tracking to avoid unsaved changes prompts
            TrackModifications = false;
            IsNew = false;
        }

        /// <summary>
        /// Service for navigating to other screens after the login.
        /// It needs to be set by the view rather than resolved, since the navigation manager must be initialized.
        /// </summary>
        public ILoginNavigation LoginNavigation { get; set; }

        // Override login to invoke the navigation after a successful login.
        protected override async Task<Output<UserInfo>> PasswordLogin_LoginAsync(object options, CancellationToken token = default)
        {
            var res = await base.PasswordLogin_LoginAsync(options, token);
            var nav = LoginNavigation ?? ServiceProvider.GetService<ILoginNavigation>();
            if (res != null && !res.Messages.HasErrors() && nav != null)
                nav.NavigateOnLogin(res.Result);
            return res;
        }
    }
}