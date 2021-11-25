
using AdventureWorks.Services.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorks.Services.Entities
{
    public partial class SalesOrderService
    {
        protected PaymentInfo GetPaymentInfo(SalesOrder obj)
        {
            PaymentInfo res = new PaymentInfo()
            {
                DueDate = obj.DueDate,
                SubTotal = obj.SubTotal,
                Freight = obj.Freight,
                TaxAmt = obj.TaxAmt,
                TotalDue = obj.TotalDue,
                ShipMethodId = obj.ShipMethodObject?.ShipMethodId ?? 0,
                CreditCardId = obj.CreditCardObject?.CreditCardId ?? 0,
                CreditCardApprovalCode = obj.CreditCardApprovalCode,
                CurrencyRate = obj.CurrencyRateObject?.RateString
            };
            return res;
        }

        protected async Task UpdatePayment(SalesOrder obj, PaymentUpdate pmt, CancellationToken token)
        {
            if (pmt == null)
            {
                currentErrors.AddValidationError(Messages.PaymentRequired, obj.SalesOrderId);
                return;
            }
            obj.DueDate = pmt.DueDate;
            obj.ShipMethodObject = await ctx.FindEntityAsync<ShipMethod>(currentErrors, token, pmt.ShipMethodId);
            obj.CreditCardApprovalCode = pmt.CreditCardApprovalCode;
            obj.CreditCardObject = await ctx.FindEntityAsync<CreditCard>(currentErrors, token, pmt.CreditCardId);
        }

        protected SalesInfo GetSalesInfo(SalesOrder obj) => new SalesInfo()
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
    }
}