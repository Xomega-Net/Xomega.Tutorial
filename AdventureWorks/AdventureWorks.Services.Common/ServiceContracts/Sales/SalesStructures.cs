//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Service Contracts" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace AdventureWorks.Services.Common
{
    #region CustomerInfo structure

    public class CustomerInfo
    {
        
        public int CustomerId { get; set; }
        
        ///<summary>
        /// Foreign key to Store.BusinessEntityID
        ///</summary>
        public int? StoreId { get; set; }
        
        public string StoreName { get; set; }
        
        ///<summary>
        /// Foreign key to Person.BusinessEntityID
        ///</summary>
        public int? PersonId { get; set; }
        
        public string PersonName { get; set; }
        
        ///<summary>
        /// Unique number identifying the customer assigned by the accounting system.
        ///</summary>
        public string AccountNumber { get; set; }
        
        ///<summary>
        /// ID of the territory in which the customer is located. Foreign key to SalesTerritory.SalesTerritoryID.
        ///</summary>
        public int? TerritoryId { get; set; }
        
        public int? BillToAddressId { get; set; }
        
        public int? ShipToAddressId { get; set; }
    }
    #endregion

    #region CustomerUpdate structure

    public class CustomerUpdate
    {
        
        public int CustomerId { get; set; }
        
        public int? BillToAddressId { get; set; }
        
        public int? ShipToAddressId { get; set; }
    }
    #endregion

    #region PaymentInfo structure

    public class PaymentInfo
    {
        
        ///<summary>
        /// Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.
        ///</summary>
        public decimal SubTotal { get; set; }
        
        ///<summary>
        /// Shipping method. Foreign key to ShipMethod.ShipMethodID.
        ///</summary>
        public int ShipMethodId { get; set; }
        
        ///<summary>
        /// Tax amount.
        ///</summary>
        public decimal TaxAmt { get; set; }
        
        ///<summary>
        /// Shipping cost.
        ///</summary>
        public decimal Freight { get; set; }
        
        ///<summary>
        /// Total due from customer. Computed as Subtotal + TaxAmt + Freight.
        ///</summary>
        public decimal TotalDue { get; set; }
        
        ///<summary>
        /// Date the order is due to the customer.
        ///</summary>
        public DateTime DueDate { get; set; }
        
        public string CurrencyRate { get; set; }
        
        ///<summary>
        /// Credit card identification number. Foreign key to CreditCard.CreditCardID.
        ///</summary>
        public int? CreditCardId { get; set; }
        
        ///<summary>
        /// Approval code provided by the credit card company.
        ///</summary>
        public string CreditCardApprovalCode { get; set; }
    }
    #endregion

    #region PaymentUpdate structure

    public class PaymentUpdate
    {
        
        ///<summary>
        /// Shipping method. Foreign key to ShipMethod.ShipMethodID.
        ///</summary>
        public int ShipMethodId { get; set; }
        
        ///<summary>
        /// Date the order is due to the customer.
        ///</summary>
        public DateTime DueDate { get; set; }
        
        ///<summary>
        /// Credit card identification number. Foreign key to CreditCard.CreditCardID.
        ///</summary>
        public int? CreditCardId { get; set; }
        
        ///<summary>
        /// Approval code provided by the credit card company.
        ///</summary>
        public string CreditCardApprovalCode { get; set; }
    }
    #endregion

    #region SalesInfo structure

    public class SalesInfo
    {
        
        ///<summary>
        /// Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.
        ///</summary>
        public int? TerritoryId { get; set; }
        
        ///<summary>
        /// Sales person who created the sales order. Foreign key to SalesPerson.BusinessEntityID.
        ///</summary>
        public int? SalesPersonId { get; set; }
        
        public ICollection<int> SalesReason { get; set; }
    }
    #endregion

}