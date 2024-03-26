using System;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorks.Client.Common.ViewModels
{
    public class LoginViewModelCustomized : LoginViewModel
    {
        public const string ParamWarning = "Warning";

        public LoginViewModelCustomized(IServiceProvider sp) : base(sp)
        {
        }

        public override async Task<bool> ActivateAsync(NameValueCollection parameters, CancellationToken token = default)
        {
            if (!await base.ActivateAsync(parameters, token)) return false;

            // Uncomment this to auto-login as a guest
            //await SaveAsync(token);
            //if (!Errors.HasErrors())
            //    return false; // don't open the view on auto-login

            if (Params[ParamWarning] != null)
                Errors.AddWarning(Params[ParamWarning]);

            return true;
        }
    }
}