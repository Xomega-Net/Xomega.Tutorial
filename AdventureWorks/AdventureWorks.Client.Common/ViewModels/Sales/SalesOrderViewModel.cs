//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "View Models" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using AdventureWorks.Client.Common.DataObjects;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Views;

namespace AdventureWorks.Client.Common.ViewModels
{
    public partial class SalesOrderViewModel : DetailsViewModel
    {
        public SalesOrderObject MainObj => DetailsObject as SalesOrderObject;

        public SalesOrderViewModel(IServiceProvider sp) : base(sp)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            DetailsObject = ServiceProvider.GetService<SalesOrderObject>();
        }

        #region Link LinkCustomerLookupLookUp

        public virtual NameValueCollection LinkCustomerLookupLookUp_Params()
        {
            NameValueCollection query = new NameValueCollection()
            {
                { ViewParams.Action.Param, ViewParams.Action.Select },
                { ViewParams.SelectionMode.Param, ViewParams.SelectionMode.Single },
                { "StoreNameOperator", "CN" },
                { "StoreName", MainObj.CustomerObject.LookupObject.StoreNameProperty.GetStringValue(ValueFormat.EditString) },
                { "PersonNameOperator", "CN" },
                { "PersonName", MainObj.CustomerObject.LookupObject.PersonNameProperty.GetStringValue(ValueFormat.EditString) },
                { ViewParams.Mode.Param, ViewParams.Mode.Popup },
                { ViewParams.QuerySource, "LinkCustomerLookupLookUp" },
            };
            return query;
        }

        public virtual void LinkCustomerLookupLookUp_Command(IView tgtView, IView curView)
        {
            NameValueCollection query = LinkCustomerLookupLookUp_Params();
            ViewModel tgtModel = ServiceProvider.GetService<CustomerListViewModel>();
            NavigateTo(tgtModel, tgtView, query, this, curView);
        }

        public virtual async Task LinkCustomerLookupLookUp_CommandAsync(IAsyncView tgtView, IAsyncView curView, CancellationToken token = default)
        {
            NameValueCollection query = LinkCustomerLookupLookUp_Params();
            ViewModel tgtModel = ServiceProvider.GetService<CustomerListViewModel>();
            await NavigateToAsync(tgtModel, tgtView, query, this, curView, token);
        }

        public virtual bool LinkCustomerLookupLookUp_Enabled()
        {
            return true;
        }

        protected virtual void LinkCustomerLookupLookUp_HandleResult(object sender, List<DataRow> selectedRows)
        {
            if (selectedRows == null || selectedRows.Count != 1) return;
            DataRow row = selectedRows[0];
            MainObj.CustomerObject.CustomerIdProperty.SetValue(DataRow.GetValue(row, CustomerList.CustomerId));
            MainObj.CustomerObject.StoreIdProperty.SetValue(DataRow.GetValue(row, CustomerList.StoreId));
            MainObj.CustomerObject.StoreNameProperty.SetValue(DataRow.GetValue(row, CustomerList.StoreName));
            MainObj.CustomerObject.PersonIdProperty.SetValue(DataRow.GetValue(row, CustomerList.PersonId));
            MainObj.CustomerObject.PersonNameProperty.SetValue(DataRow.GetValue(row, CustomerList.PersonName));
            MainObj.CustomerObject.AccountNumberProperty.SetValue(DataRow.GetValue(row, CustomerList.AccountNumber));
            MainObj.CustomerObject.TerritoryIdProperty.SetValue(DataRow.GetValue(row, CustomerList.TerritoryId));
        }
        #endregion

        #region Link LinkDetailDetails

        public virtual NameValueCollection LinkDetailDetails_Params(DataRow row)
        {
            NameValueCollection query = new NameValueCollection()
            {
                { "SalesOrderDetailId", MainObj.DetailList.SalesOrderDetailIdProperty.GetStringValue(ValueFormat.EditString, row) },
                { ViewParams.Mode.Param, ViewParams.Mode.Popup },
                { ViewParams.QuerySource, "LinkDetailDetails" },
            };
            return query;
        }

        public virtual void LinkDetailDetails_Command(IView tgtView, IView curView, DataRow row)
        {
            NameValueCollection query = LinkDetailDetails_Params(row);
            ViewModel tgtModel = ServiceProvider.GetService<SalesOrderDetailViewModel>();
            NavigateTo(tgtModel, tgtView, query, this, curView);
        }

        public virtual async Task LinkDetailDetails_CommandAsync(IAsyncView tgtView, IAsyncView curView, DataRow row, CancellationToken token = default)
        {
            NameValueCollection query = LinkDetailDetails_Params(row);
            ViewModel tgtModel = ServiceProvider.GetService<SalesOrderDetailViewModel>();
            await NavigateToAsync(tgtModel, tgtView, query, this, curView, token);
        }

        public virtual bool LinkDetailDetails_Enabled(DataRow row)
        {
            return true;
        }
        #endregion

        #region Link LinkDetailNew

        public virtual NameValueCollection LinkDetailNew_Params()
        {
            NameValueCollection query = new NameValueCollection()
            {
                { ViewParams.Action.Param, ViewParams.Action.Create },
                { "SalesOrderId", MainObj.SalesOrderIdProperty.GetStringValue(ValueFormat.EditString) },
                { ViewParams.Mode.Param, ViewParams.Mode.Popup },
                { ViewParams.QuerySource, "LinkDetailNew" },
            };
            return query;
        }

        public virtual void LinkDetailNew_Command(IView tgtView, IView curView)
        {
            NameValueCollection query = LinkDetailNew_Params();
            ViewModel tgtModel = ServiceProvider.GetService<SalesOrderDetailViewModel>();
            NavigateTo(tgtModel, tgtView, query, this, curView);
        }

        public virtual async Task LinkDetailNew_CommandAsync(IAsyncView tgtView, IAsyncView curView, CancellationToken token = default)
        {
            NameValueCollection query = LinkDetailNew_Params();
            ViewModel tgtModel = ServiceProvider.GetService<SalesOrderDetailViewModel>();
            await NavigateToAsync(tgtModel, tgtView, query, this, curView, token);
        }

        public virtual bool LinkDetailNew_Enabled()
        {
            return !DetailsObject.IsNew;
        }
        #endregion
         
        #region Child selection event
          
        protected virtual void HandleSelection(object sender, ViewEvent e)
        {
            ViewModel child = sender as ViewModel;
            if (e is ViewSelectionEvent && child?.Params?[ViewParams.QuerySource] == "LinkCustomerLookupLookUp")
                LinkCustomerLookupLookUp_HandleResult(sender, ((ViewSelectionEvent)e).SelectedRows);
        }

        protected override void OnChildEvent(object sender, ViewEvent e)
        {
            HandleSelection(sender, e);
            base.OnChildEvent(sender, e);
        }

        protected override async Task OnChildEventAsync(object sender, ViewEvent e, CancellationToken token = default)
        {
            HandleSelection(sender, e);
            await base.OnChildEventAsync(sender, e, token);
        }
        #endregion
    }
}