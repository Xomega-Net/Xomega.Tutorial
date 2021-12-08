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
    #region ISpecialOfferProductService interface

    ///<summary>
    /// Cross-reference table mapping products to special offer discounts.
    ///</summary>
    public interface ISpecialOfferProductService
    {

        ///<summary>
        /// Reads a list of Special Offer Product objects based on the specified criteria.
        ///</summary>
        Task<Output<ICollection<SpecialOfferProduct_ReadListOutput>>> ReadListAsync(int _productId, CancellationToken token = default);

    }
    #endregion

    #region SpecialOfferProduct_ReadListOutput structure

    ///<summary>
    /// The output structure of operation ISpecialOfferProductService.ReadListAsync.
    ///</summary>
    public class SpecialOfferProduct_ReadListOutput
    {
        
        public int SpecialOfferId { get; set; }
        
        public string Description { get; set; }
        
        public decimal? Discount { get; set; }
        
        public int? MinQty { get; set; }
        
        public int? MaxQty { get; set; }
        
        public bool? Active { get; set; }
    }
    #endregion

}