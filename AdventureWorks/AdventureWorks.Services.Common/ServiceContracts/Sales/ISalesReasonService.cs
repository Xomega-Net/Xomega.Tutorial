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
    #region ISalesReasonService interface

    ///<summary>
    /// Lookup table of customer purchase reasons.
    ///</summary>
    public interface ISalesReasonService
    {

        ///<summary>
        /// Reads a list of Sales Reason objects based on the specified criteria.
        ///</summary>
        Task<Output<ICollection<SalesReason_ReadListOutput>>> ReadListAsync(CancellationToken token = default);

    }
    #endregion

    #region SalesReason_ReadListOutput structure

    ///<summary>
    /// The output structure of operation ISalesReasonService.ReadListAsync.
    ///</summary>
    public class SalesReason_ReadListOutput
    {
        
        public int SalesReasonId { get; set; }
        
        ///<summary>
        /// Sales reason description.
        ///</summary>
        public string Name { get; set; }
    }
    #endregion

}