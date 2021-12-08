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
    #region IProductSubcategoryService interface

    ///<summary>
    /// Product subcategories. See ProductCategory table.
    ///</summary>
    public interface IProductSubcategoryService
    {

        ///<summary>
        /// Reads a list of Product Subcategory objects based on the specified criteria.
        ///</summary>
        Task<Output<ICollection<ProductSubcategory_ReadListOutput>>> ReadListAsync(CancellationToken token = default);

    }
    #endregion

    #region ProductSubcategory_ReadListOutput structure

    ///<summary>
    /// The output structure of operation IProductSubcategoryService.ReadListAsync.
    ///</summary>
    public class ProductSubcategory_ReadListOutput
    {
        
        public int ProductSubcategoryId { get; set; }
        
        ///<summary>
        /// Product category identification number. Foreign key to ProductCategory.ProductCategoryID.
        ///</summary>
        public int ProductCategoryId { get; set; }
        
        ///<summary>
        /// Subcategory description.
        ///</summary>
        public string Name { get; set; }
    }
    #endregion

}