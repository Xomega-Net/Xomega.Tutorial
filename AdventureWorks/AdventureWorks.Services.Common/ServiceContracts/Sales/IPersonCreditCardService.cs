//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Service Contracts" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Common
{
    #region IPersonCreditCardService interface

    ///<summary>
    /// Cross-reference table mapping people to their credit card information in the CreditCard table. 
    ///</summary>
    public interface IPersonCreditCardService
    {

        ///<summary>
        /// Reads a list of Person Credit Card objects based on the specified criteria.
        ///</summary>
        Task<Output<ICollection<PersonCreditCard_ReadListOutput>>> ReadListAsync(int _businessEntityId, CancellationToken token = default);

    }
    #endregion

    #region PersonCreditCard_ReadListOutput structure

    ///<summary>
    /// The output structure of operation IPersonCreditCardService.ReadListAsync.
    ///</summary>
    public class PersonCreditCard_ReadListOutput
    {
        
        public int CreditCardId { get; set; }
        
        public string CreditCardName { get; set; }
        
        public string PersonName { get; set; }
        
        public string CardType { get; set; }
        
        public string CardNumber { get; set; }
        
        public byte ExpMonth { get; set; }
        
        public short ExpYear { get; set; }
    }
    #endregion

}