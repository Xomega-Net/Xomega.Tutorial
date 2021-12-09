//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Service Contracts" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Common
{
    #region IPersonService interface

    ///<summary>
    /// Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts.
    ///</summary>
    public interface IPersonService
    {

        ///<summary>
        /// Authenticates a Person using email and password.
        ///</summary>
        Task<Output> AuthenticateAsync(Credentials _credentials, CancellationToken token = default);

        ///<summary>
        /// Reads person info by email as the key.
        ///</summary>
        Task<Output<PersonInfo>> ReadAsync(string _email, CancellationToken token = default);

    }
    #endregion

}