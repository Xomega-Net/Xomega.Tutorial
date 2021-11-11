//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Xomega Data Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using AdventureWorks.Services.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Properties;
using Xomega.Framework.Services;

namespace AdventureWorks.Client.Common.DataObjects
{
    public partial class SalesOrderReasonObject : DataObject
    {
        #region Constants

        public const string ModifiedDate = "ModifiedDate";
        public const string SalesOrderId = "SalesOrderId";
        public const string SalesReasonId = "SalesReasonId";

        #endregion

        #region Properties

        public DateTimeProperty ModifiedDateProperty { get; private set; }
        public IntegerKeyProperty SalesOrderIdProperty { get; private set; }
        public IntegerKeyProperty SalesReasonIdProperty { get; private set; }

        #endregion

        #region Construction

        public SalesOrderReasonObject()
        {
        }

        public SalesOrderReasonObject(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void Initialize()
        {
            SalesOrderIdProperty = new IntegerKeyProperty(this, SalesOrderId)
            {
                Required = true,
            };
            SalesReasonIdProperty = new IntegerKeyProperty(this, SalesReasonId)
            {
                Required = true,
                IsKey = true,
            };
            ModifiedDateProperty = new DateTimeProperty(this, ModifiedDate)
            {
                Required = true,
            };

            // make create keys editable only for new objects
            Expression<Func<DataObject, bool>> xIsNew = obj => obj.IsNew;
            SalesOrderIdProperty.SetComputedEditable(xIsNew, this);
            SalesReasonIdProperty.SetComputedEditable(xIsNew, this);
        }

        #endregion

        #region CRUD Operations

        protected override async Task<ErrorList> DoReadAsync(object options, CancellationToken token = default)
        {
            var output = await SalesOrder_Reason_ReadAsync(options, token);
            return output.Messages;
        }

        protected override async Task<ErrorList> DoSaveAsync(object options, CancellationToken token = default)
        {
            if (IsNew)
            {
                var output = await SalesOrder_Reason_CreateAsync(options, token);
                return output.Messages;
            }
            else
            {
                var output = await SalesOrder_Reason_UpdateAsync(options, token);
                return output.Messages;
            }
        }

        protected override async Task<ErrorList> DoDeleteAsync(object options, CancellationToken token = default)
        {
            var output = await SalesOrder_Reason_DeleteAsync(options, token);
            return output.Messages;
        }

        #endregion

        #region Service Operations

        protected virtual async Task<Output<SalesOrderReason_ReadOutput>> SalesOrder_Reason_ReadAsync(object options, CancellationToken token = default)
        {
            int _salesOrderId = (int)SalesOrderIdProperty.TransportValue;
            int _salesReasonId = (int)SalesReasonIdProperty.TransportValue;
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<ISalesOrderService>().Reason_ReadAsync(_salesOrderId, _salesReasonId, token);

                await FromDataContractAsync(output?.Result, options, token);
                return output;
            }
        }

        protected virtual async Task<Output> SalesOrder_Reason_CreateAsync(object options, CancellationToken token = default)
        {
            int _salesOrderId = (int)SalesOrderIdProperty.TransportValue;
            int _salesReasonId = (int)SalesReasonIdProperty.TransportValue;
            SalesOrderReason_CreateInput_Data _data = ToDataContract<SalesOrderReason_CreateInput_Data>(options);
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<ISalesOrderService>().Reason_CreateAsync(_salesOrderId, _salesReasonId, _data, token);

                return output;
            }
        }

        protected virtual async Task<Output> SalesOrder_Reason_UpdateAsync(object options, CancellationToken token = default)
        {
            int _salesOrderId = (int)SalesOrderIdProperty.TransportValue;
            int _salesReasonId = (int)SalesReasonIdProperty.TransportValue;
            SalesOrderReason_UpdateInput_Data _data = ToDataContract<SalesOrderReason_UpdateInput_Data>(options);
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<ISalesOrderService>().Reason_UpdateAsync(_salesOrderId, _salesReasonId, _data, token);

                return output;
            }
        }

        protected virtual async Task<Output> SalesOrder_Reason_DeleteAsync(object options, CancellationToken token = default)
        {
            int _salesOrderId = (int)SalesOrderIdProperty.TransportValue;
            int _salesReasonId = (int)SalesReasonIdProperty.TransportValue;
            using (var s = ServiceProvider.CreateScope())
            {
                var output = await s.ServiceProvider.GetService<ISalesOrderService>().Reason_DeleteAsync(_salesOrderId, _salesReasonId, token);

                return output;
            }
        }

        #endregion
    }
}