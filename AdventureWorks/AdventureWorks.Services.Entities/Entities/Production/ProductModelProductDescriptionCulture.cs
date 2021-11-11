//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System;

namespace AdventureWorks.Services.Entities
{
    ///<summary>
    /// Cross-reference table mapping product descriptions and the language the description is written in.
    ///</summary>
    public partial class ProductModelProductDescriptionCulture
    {
        public ProductModelProductDescriptionCulture()
        {
        }

        #region Properties

        ///<summary>
        /// Primary key. Foreign key to ProductModel.ProductModelID.
        ///</summary>
        public int ProductModelId  { get; set; }

        ///<summary>
        /// Primary key. Foreign key to ProductDescription.ProductDescriptionID.
        ///</summary>
        public int ProductDescriptionId  { get; set; }

        ///<summary>
        /// Culture identification number. Foreign key to Culture.CultureID.
        ///</summary>
        public string CultureId  { get; set; }

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public DateTime ModifiedDate  { get; set; }

        #endregion

        #region Navigation Properties

        ///<summary>
        /// ProductModel object referenced by the field ProductModelId.
        ///</summary>
        public virtual ProductModel ProductModelObject { get; set; }

        ///<summary>
        /// ProductDescription object referenced by the field ProductDescriptionId.
        ///</summary>
        public virtual ProductDescription ProductDescriptionObject { get; set; }

        ///<summary>
        /// Culture object referenced by the field CultureId.
        ///</summary>
        public virtual Culture CultureObject { get; set; }

        #endregion
    }
}