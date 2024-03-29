//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Service Implementations" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated
// unless they are placed between corresponding CUSTOM_CODE_START/CUSTOM_CODE_END lines.
//---------------------------------------------------------------------------------------------

using AdventureWorks.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework.Services;
// CUSTOM_CODE_START: add namespaces for custom code below
using AdventureWorks.Services.Common.Enumerations;
using Xomega.Framework;
// CUSTOM_CODE_END

namespace AdventureWorks.Services.Entities
{
    public partial class SalesOrderService : BaseService, ISalesOrderService
    {
        protected AdventureWorksEntities ctx;

        public SalesOrderService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            ctx = serviceProvider.GetService<AdventureWorksEntities>();
        }

        public virtual async Task<Output<SalesOrder_ReadOutput>> ReadAsync(int _salesOrderId, CancellationToken token = default)
        {
            SalesOrder_ReadOutput res = new SalesOrder_ReadOutput();
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Read operation below
                // CUSTOM_CODE_END
                SalesOrder obj = await ctx.FindEntityAsync<SalesOrder>(currentErrors, token, _salesOrderId);
                ServiceUtil.CopyProperties(obj, res);
                // CUSTOM_CODE_START: populate the Customer output structure of Read operation below
                res.Customer = GetCustomerInfo(obj); // CUSTOM_CODE_END
                // CUSTOM_CODE_START: populate the Payment output structure of Read operation below
                res.Payment = GetPaymentInfo(obj); // CUSTOM_CODE_END
                // CUSTOM_CODE_START: populate the Sales output structure of Read operation below
                res.Sales = GetSalesInfo(obj); // CUSTOM_CODE_END
                // CUSTOM_CODE_START: add custom code for Read operation below
                // CUSTOM_CODE_END
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output<SalesOrder_ReadOutput>(currentErrors, res));
        }

        public virtual async Task<Output<SalesOrder_CreateOutput>> CreateAsync(SalesOrder_CreateInput _data, CancellationToken token = default)
        {
            SalesOrder_CreateOutput res = new SalesOrder_CreateOutput();
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Create operation below
                // CUSTOM_CODE_END
                EntityState state = EntityState.Added;
                SalesOrder obj = new SalesOrder();
                var entry = ctx.Entry(obj);
                entry.State = state;
                entry.CurrentValues.SetValues(_data);
                // CUSTOM_CODE_START: use the Customer input parameter of Create operation below
                await UpdateCustomer(obj, _data.Customer); // CUSTOM_CODE_END
                // CUSTOM_CODE_START: use the Payment input parameter of Create operation below
                await UpdatePayment(obj, _data.Payment, token); // CUSTOM_CODE_END
                // CUSTOM_CODE_START: use the Sales input parameter of Create operation below
                await UpdateSalesInfo(obj, _data.Sales); // CUSTOM_CODE_END
                // CUSTOM_CODE_START: add custom code for Create operation below
                obj.OrderDate = DateTime.Now;
                obj.ModifiedDate = DateTime.Now;
                obj.Rowguid = Guid.NewGuid();
                // CUSTOM_CODE_END
                currentErrors.AbortIfHasErrors();
                await ctx.SaveChangesAsync(token);
                ServiceUtil.CopyProperties(obj, res);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output<SalesOrder_CreateOutput>(currentErrors, res));
        }

        public virtual async Task<Output<SalesOrder_UpdateOutput>> UpdateAsync(int _salesOrderId, SalesOrder_UpdateInput_Data _data, CancellationToken token = default)
        {
            SalesOrder_UpdateOutput res = new SalesOrder_UpdateOutput();
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Update operation below
                // CUSTOM_CODE_END
                SalesOrder obj = await ctx.FindEntityAsync<SalesOrder>(currentErrors, token, _salesOrderId);
                var entry = ctx.Entry(obj);
                entry.CurrentValues.SetValues(_data);
                // CUSTOM_CODE_START: use the Customer input parameter of Update operation below
                await UpdateCustomer(obj, _data.Customer); // CUSTOM_CODE_END
                // CUSTOM_CODE_START: use the Payment input parameter of Update operation below
                await UpdatePayment(obj, _data.Payment, token); // CUSTOM_CODE_END
                // CUSTOM_CODE_START: use the Sales input parameter of Update operation below
                await UpdateSalesInfo(obj, _data.Sales); // CUSTOM_CODE_END
                // CUSTOM_CODE_START: add custom code for Update operation below
                obj.ModifiedDate = DateTime.Now;
                // CUSTOM_CODE_END
                currentErrors.AbortIfHasErrors();
                await ctx.SaveChangesAsync(token);
                ServiceUtil.CopyProperties(obj, res);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output<SalesOrder_UpdateOutput>(currentErrors, res));
        }

        public virtual async Task<Output> DeleteAsync(int _salesOrderId, CancellationToken token = default)
        {
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Delete operation below
                // CUSTOM_CODE_END
                EntityState state = EntityState.Deleted;
                SalesOrder obj = await ctx.FindEntityAsync<SalesOrder>(currentErrors, token, _salesOrderId);
                var entry = ctx.Entry(obj);
                entry.State = state;
                // CUSTOM_CODE_START: add custom code for Delete operation below
                // CUSTOM_CODE_END
                currentErrors.AbortIfHasErrors();
                await ctx.SaveChangesAsync(token);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output(currentErrors));
        }

        public virtual async Task<Output<ICollection<SalesOrder_ReadListOutput>>> ReadListAsync(SalesOrder_ReadListInput_Criteria _criteria, CancellationToken token = default)
        {
            ICollection<SalesOrder_ReadListOutput> res = null;
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for ReadList operation below
                if (!CurrentPrincipal.IsEmployee() && !CurrentPrincipal.IsIndividualCustomer() && 
                    !CurrentPrincipal.IsStoreContact())
                {
                    currentErrors.CriticalError(ErrorType.Security, Messages.OperationNotAllowed);
                }
                // CUSTOM_CODE_END
                var src = from obj in ctx.SalesOrder select obj;

                // Source filter
                if (_criteria != null)
                {
                    // CUSTOM_CODE_START: add code for GlobalRegion criteria of ReadList operation below
                    src = AddClause(src, "GlobalRegion", o => o.TerritoryObject.Group,
                        Operators.IsEqualTo, _criteria.GlobalRegion);
                    // CUSTOM_CODE_END
                }

                // CUSTOM_CODE_START: add custom filter criteria to the source query for ReadList operation below
                if (CurrentPrincipal.IsStoreContact())
                {
                    int? storeId = CurrentPrincipal.GetStoreId();
                    src = src.Where(o => o.CustomerObject.StoreObject.BusinessEntityId == storeId);
                }
                if (CurrentPrincipal.IsIndividualCustomer())
                {
                    int? personId = CurrentPrincipal.GetPersonId();
                    src = src.Where(o => o.CustomerObject.PersonObject.BusinessEntityId == personId);
                }
                // CUSTOM_CODE_END

                var qry = from obj in src
                          select new SalesOrder_ReadListOutput() {
                              SalesOrderId = obj.SalesOrderId,
                              SalesOrderNumber = obj.SalesOrderNumber,
                              OrderDate = obj.OrderDate,
                              DueDate = obj.DueDate,
                              ShipDate = obj.ShipDate,
                              Status = obj.Status,
                              OnlineOrderFlag = obj.OnlineOrderFlag,
                              // CUSTOM_CODE_START: set the CustomerStore output parameter of ReadList operation below
                              CustomerStore = obj.CustomerObject.StoreObject.Name, // CUSTOM_CODE_END
                              // CUSTOM_CODE_START: set the CustomerName output parameter of ReadList operation below
                              CustomerName = obj.CustomerObject.PersonObject.LastName + ", " +
                                             obj.CustomerObject.PersonObject.FirstName, // CUSTOM_CODE_END
                              SalesPersonId = obj.SalesPersonId,
                              TerritoryId = obj.TerritoryId,
                              TotalDue = obj.TotalDue,
                          };

                // Result filter
                if (_criteria != null)
                {
                    qry = AddClause(qry, "SalesOrderNumber", o => o.SalesOrderNumber, _criteria.SalesOrderNumberOperator, _criteria.SalesOrderNumber);
                    qry = AddClause(qry, "Status", o => o.Status, _criteria.StatusOperator, _criteria.Status);
                    qry = AddClause(qry, "OrderDate", o => o.OrderDate, _criteria.OrderDateOperator, _criteria.OrderDate, _criteria.OrderDate2);
                    qry = AddClause(qry, "DueDate", o => o.DueDate, _criteria.DueDateOperator, _criteria.DueDate, _criteria.DueDate2);
                    qry = AddClause(qry, "TotalDue", o => o.TotalDue, _criteria.TotalDueOperator, _criteria.TotalDue, _criteria.TotalDue2);
                    qry = AddClause(qry, "CustomerStore", o => o.CustomerStore, _criteria.CustomerStoreOperator, _criteria.CustomerStore);
                    qry = AddClause(qry, "CustomerName", o => o.CustomerName, _criteria.CustomerNameOperator, _criteria.CustomerName);
                    qry = AddClause(qry, "TerritoryId", o => o.TerritoryId, _criteria.TerritoryIdOperator, _criteria.TerritoryId);
                    qry = AddClause(qry, "SalesPersonId", o => o.SalesPersonId, _criteria.SalesPersonIdOperator, _criteria.SalesPersonId);
                }

                // CUSTOM_CODE_START: add custom filter criteria to the result query for ReadList operation below
                // qry = qry.Where(o => o.FieldName == VALUE);
                // CUSTOM_CODE_END

                currentErrors.AbortIfHasErrors();
                res = await qry.ToListAsync(token);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output<ICollection<SalesOrder_ReadListOutput>>(currentErrors, res));
        }

        public virtual async Task<Output<SalesOrderDetail_ReadOutput>> Detail_ReadAsync(int _salesOrderDetailId, CancellationToken token = default)
        {
            SalesOrderDetail_ReadOutput res = new SalesOrderDetail_ReadOutput();
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Detail_Read operation below
                // CUSTOM_CODE_END
                SalesOrderDetail obj = await ctx.FindEntityAsync<SalesOrderDetail>(currentErrors, token, _salesOrderDetailId);
                ServiceUtil.CopyProperties(obj, res);
                // CUSTOM_CODE_START: set the SalesOrderNumber output field of Detail_Read operation below
                res.SalesOrderNumber = obj.SalesOrderObject.SalesOrderNumber; // CUSTOM_CODE_END
                // CUSTOM_CODE_START: set the Subcategory output field of Detail_Read operation below
                res.Subcategory = obj.SpecialOfferProductObject.ProductObject.ProductSubcategoryId; // CUSTOM_CODE_END
                // CUSTOM_CODE_START: add custom code for Detail_Read operation below
                // CUSTOM_CODE_END
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output<SalesOrderDetail_ReadOutput>(currentErrors, res));
        }

        public virtual async Task<Output<SalesOrderDetail_CreateOutput>> Detail_CreateAsync(int _salesOrderId, SalesOrderDetail_CreateInput_Data _data, CancellationToken token = default)
        {
            SalesOrderDetail_CreateOutput res = new SalesOrderDetail_CreateOutput();
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Detail_Create operation below
                // CUSTOM_CODE_END
                EntityState state = EntityState.Added;
                SalesOrderDetail obj = new SalesOrderDetail();
                var entry = ctx.Entry(obj);
                entry.State = state;
                obj.SalesOrderId = _salesOrderId;
                entry.CurrentValues.SetValues(_data);
                await ctx.ValidateKeyAsync<SalesOrder>(currentErrors, token, "SalesOrderId", _salesOrderId);
                await ctx.ValidateKeyAsync<SpecialOfferProduct>(currentErrors, token, "SpecialOfferId, ProductId", _data.SpecialOfferId, _data.ProductId);
                // CUSTOM_CODE_START: add custom code for Detail_Create operation below
                UpdateOrderDetail(obj);
                // CUSTOM_CODE_END
                currentErrors.AbortIfHasErrors();
                await ctx.SaveChangesAsync(token);
                ServiceUtil.CopyProperties(obj, res);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output<SalesOrderDetail_CreateOutput>(currentErrors, res));
        }

        public virtual async Task<Output> Detail_UpdateAsync(int _salesOrderDetailId, SalesOrderDetail_UpdateInput_Data _data, CancellationToken token = default)
        {
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Detail_Update operation below
                // CUSTOM_CODE_END
                SalesOrderDetail obj = await ctx.FindEntityAsync<SalesOrderDetail>(currentErrors, token, _salesOrderDetailId);
                var entry = ctx.Entry(obj);
                entry.CurrentValues.SetValues(_data);
                await ctx.ValidateKeyAsync<SpecialOfferProduct>(currentErrors, token, "SpecialOfferId, ProductId", _data.SpecialOfferId, _data.ProductId);
                // CUSTOM_CODE_START: add custom code for Detail_Update operation below
                UpdateOrderDetail(obj);
                // CUSTOM_CODE_END
                currentErrors.AbortIfHasErrors();
                await ctx.SaveChangesAsync(token);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output(currentErrors));
        }

        public virtual async Task<Output> Detail_DeleteAsync(int _salesOrderDetailId, CancellationToken token = default)
        {
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Detail_Delete operation below
                // CUSTOM_CODE_END
                EntityState state = EntityState.Deleted;
                SalesOrderDetail obj = await ctx.FindEntityAsync<SalesOrderDetail>(currentErrors, token, _salesOrderDetailId);
                var entry = ctx.Entry(obj);
                entry.State = state;
                // CUSTOM_CODE_START: add custom code for Detail_Delete operation below
                // CUSTOM_CODE_END
                currentErrors.AbortIfHasErrors();
                await ctx.SaveChangesAsync(token);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output(currentErrors));
        }

        public virtual async Task<Output<ICollection<SalesOrderDetail_ReadListOutput>>> Detail_ReadListAsync(int _salesOrderId, CancellationToken token = default)
        {
            ICollection<SalesOrderDetail_ReadListOutput> res = null;
            try
            {
                currentErrors.AbortIfHasErrors();

                // CUSTOM_CODE_START: add custom security checks for Detail_ReadList operation below
                // CUSTOM_CODE_END
                var src = from obj in ctx.SalesOrderDetail select obj;

                // Source filter
                src = AddClause(src, "SalesOrderId", o => o.SalesOrderId, new [] { _salesOrderId });

                // CUSTOM_CODE_START: add custom filter criteria to the source query for Detail_ReadList operation below
                // src = src.Where(o => o.FieldName == VALUE);
                // CUSTOM_CODE_END

                var qry = from obj in src
                          select new SalesOrderDetail_ReadListOutput() {
                              SalesOrderDetailId = obj.SalesOrderDetailId,
                              ProductId = obj.ProductId,
                              OrderQty = obj.OrderQty,
                              UnitPrice = obj.UnitPrice,
                              UnitPriceDiscount = obj.UnitPriceDiscount,
                              SpecialOfferId = obj.SpecialOfferId,
                              LineTotal = obj.LineTotal,
                              CarrierTrackingNumber = obj.CarrierTrackingNumber,
                          };

                // CUSTOM_CODE_START: add custom filter criteria to the result query for Detail_ReadList operation below
                // qry = qry.Where(o => o.FieldName == VALUE);
                // CUSTOM_CODE_END

                currentErrors.AbortIfHasErrors();
                res = await qry.ToListAsync(token);
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorParser.FromException(ex));
            }
            return await Task.FromResult(new Output<ICollection<SalesOrderDetail_ReadListOutput>>(currentErrors, res));
        }
    }
}