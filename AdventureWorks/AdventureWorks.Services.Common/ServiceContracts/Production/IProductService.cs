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
    #region IProductService interface

    ///<summary>
    /// Products sold or used in the manfacturing of sold products.
    ///</summary>
    public interface IProductService
    {

        ///<summary>
        /// Reads a list of Product objects based on the specified criteria.
        ///</summary>
        Task<Output<ICollection<Product_ReadListOutput>>> ReadListAsync(CancellationToken token = default);

    }
    #endregion

    #region Product_ReadListOutput structure

    ///<summary>
    /// The output structure of operation IProductService.ReadListAsync.
    ///</summary>
    public class Product_ReadListOutput
    {
        
        public int ProductId { get; set; }
        
        ///<summary>
        /// Name of the product.
        ///</summary>
        public string Name { get; set; }
        
        public bool IsActive { get; set; }
        
        ///<summary>
        /// Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. 
        ///</summary>
        public int? ProductSubcategoryId { get; set; }
        
        ///<summary>
        /// Product is a member of this product model. Foreign key to ProductModel.ProductModelID.
        ///</summary>
        public int? ProductModelId { get; set; }
    }
    #endregion

}