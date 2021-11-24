
using AdventureWorks.Services.Common;
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
    }
}