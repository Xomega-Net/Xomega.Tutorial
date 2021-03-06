//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Xomega Data Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using AdventureWorks.Services.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Properties;
using Xomega.Framework.Services;

namespace AdventureWorks.Client.Common.DataObjects
{
    public partial class AuthenticationObject : DataObject
    {
        #region Constants

        public const string Email = "Email";
        public const string Password = "Password";

        #endregion

        #region Properties

        public TextProperty EmailProperty { get; private set; }
        public TextProperty PasswordProperty { get; private set; }

        #endregion

        #region Construction

        public AuthenticationObject()
        {
        }

        public AuthenticationObject(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void Initialize()
        {
            EmailProperty = new TextProperty(this, Email)
            {
                Required = true,
                Size = 50,
            };
            PasswordProperty = new TextProperty(this, Password)
            {
                Required = true,
            };
        }

        #endregion

        #region CRUD Operations

        protected override async Task<ErrorList> DoSaveAsync(object options, CancellationToken token = default)
        {
            var output = await Person_AuthenticateAsync(options, token);
            return output.Messages;
        }

        #endregion

        #region Service Operations

        protected virtual async Task<Output> Person_AuthenticateAsync(object options, CancellationToken token = default)
        {
            Credentials _credentials = ToDataContract<Credentials>(options);
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<IPersonService>().AuthenticateAsync(_credentials, token);

                return output;
            }
        }

        #endregion
    }
}