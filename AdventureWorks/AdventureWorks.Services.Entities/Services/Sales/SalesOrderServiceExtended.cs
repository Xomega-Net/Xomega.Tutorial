
using AdventureWorks.Services.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Xomega.Framework;
using System;

namespace AdventureWorks.Services.Entities
{
    public partial class SalesOrderService
    {
        protected static PaymentInfo GetPaymentInfo(SalesOrder obj) => new()
        {
            DueDate = obj.DueDate,
            SubTotal = obj.SubTotal,
            Freight = obj.Freight,
            TaxAmt = obj.TaxAmt,
            TotalDue = obj.TotalDue,
            ShipMethodId = obj.ShipMethodObject?.ShipMethodId ?? 0,
            CreditCard = new SalesOrderCreditCard
            {
                CreditCardId = obj.CreditCardObject?.CreditCardId ?? 0,
                CreditCardApprovalCode = obj.CreditCardApprovalCode,
            },
            CurrencyRate = obj.CurrencyRateObject?.RateString
        };

        protected async Task UpdatePayment(SalesOrder obj, PaymentUpdate pmt, CancellationToken token)
        {
            if (pmt == null)
            {
                currentErrors.AddValidationError(Messages.PaymentRequired, obj.SalesOrderId);
                return;
            }
            obj.DueDate = pmt.DueDate;
            obj.ShipMethodObject = await ctx.FindEntityAsync<ShipMethod>(currentErrors, token, pmt.ShipMethodId);
            obj.CreditCardApprovalCode = pmt.CreditCard.CreditCardApprovalCode;
            obj.CreditCardObject = await ctx.FindEntityAsync<CreditCard>(currentErrors, token, pmt.CreditCard.CreditCardId);
        }

        protected static SalesInfo GetSalesInfo(SalesOrder obj) => new()
        {
            SalesPersonId = obj.SalesPersonId,
            TerritoryId = obj.TerritoryId,
            // select a list of sales reason IDs from the child list
            SalesReason = obj.ReasonObjectList?.Select(r => r.SalesReasonId).ToList()
        };

        protected async Task UpdateSalesInfo(SalesOrder obj, SalesInfo _data)
        {
            if (_data == null)
            {
                currentErrors.AddValidationError(Messages.SalesRequired, obj.SalesOrderId);
                return;
            }
            obj.TerritoryObject = _data.TerritoryId == null ? null :
                await ctx.FindEntityAsync<SalesTerritory>(currentErrors, _data.TerritoryId);
            obj.SalesPersonObject = _data.SalesPersonId == null ? null :
                await ctx.FindEntityAsync<SalesPerson>(currentErrors, _data.SalesPersonId);

            // remove sales reasons that are not in the provided list
            obj.ReasonObjectList
                .Where(r => _data.SalesReason == null || !_data.SalesReason.Contains(r.SalesReasonId))
                .ToList().ForEach(r => obj.ReasonObjectList.Remove(r));
            if (_data.SalesReason != null)
            {
                // add sales reasons from provided list that don't exist yet
                _data.SalesReason
                    .Where(rId => !obj.ReasonObjectList.Any(r => r.SalesReasonId == rId))
                    .ToList().ForEach(rId => obj.ReasonObjectList.Add(new SalesOrderReason()
                    {
                        SalesOrderId = obj.SalesOrderId,
                        SalesReasonId = rId,
                        ModifiedDate = DateTime.Now
                    }));
            }
        }

        protected static CustomerInfo GetCustomerInfo(SalesOrder obj) => new()
        {
            CustomerId = obj.CustomerId,
            AccountNumber = obj.CustomerObject?.AccountNumber,
            PersonId = obj.CustomerObject?.PersonObject?.BusinessEntityId,
            PersonName = obj.CustomerObject?.PersonObject?.FullName,
            StoreId = obj.CustomerObject?.StoreObject?.BusinessEntityId,
            StoreName = obj.CustomerObject?.StoreObject?.Name,
            TerritoryId = obj.CustomerObject?.TerritoryObject?.TerritoryId,
            BillingAddress = new AddressKey { AddressId = obj.BillToAddressId },
            ShippingAddress = new AddressKey { AddressId = obj.ShipToAddressId },
        };

        protected async Task UpdateCustomer(SalesOrder obj, CustomerUpdate _data)
        {
            if (_data == null)
            {
                currentErrors.AddValidationError(Messages.CustomerRequired, obj.SalesOrderId);
                return;
            }
            obj.CustomerObject = await ctx.FindEntityAsync<Customer>(currentErrors, _data.CustomerId);
            obj.BillToAddressObject = await ctx.FindEntityAsync<Address>(currentErrors, _data.BillingAddress.AddressId);
            obj.ShipToAddressObject = await ctx.FindEntityAsync<Address>(currentErrors, _data.ShippingAddress.AddressId);
        }

        protected void UpdateOrderDetail(SalesOrderDetail obj)
        {
            currentErrors.AbortIfHasErrors(); // prevent invalid data

            obj.UnitPrice = obj.SpecialOfferProductObject.ProductObject.ListPrice;
            obj.UnitPriceDiscount = obj.SpecialOfferProductObject.SpecialOfferObject.DiscountPct;
            obj.LineTotal = obj.OrderQty * obj.UnitPrice * (1 - obj.UnitPriceDiscount);

            obj.ModifiedDate = DateTime.Now;
            if (obj.Rowguid == default)
                obj.Rowguid = Guid.NewGuid();
        }
    }
}