//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "REST Service Clients" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Common
{
    ///<summary>
    /// General sales order information.
    ///</summary>
    public class SalesOrderServiceClient : HttpServiceClient, ISalesOrderService
    {
        protected readonly JsonSerializerOptions SerializerOptions;

        public SalesOrderServiceClient(HttpClient httpClient, IOptionsMonitor<JsonSerializerOptions> options)
            : base(httpClient)
        {
            SerializerOptions = options.CurrentValue;
        }

        /// <inheritdoc/>
        public virtual async Task<Output<SalesOrder_ReadOutput>> ReadAsync(int _salesOrderId, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, $"sales-order/{ _salesOrderId }");
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output<SalesOrder_ReadOutput>>(content, SerializerOptions);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<Output<SalesOrder_CreateOutput>> CreateAsync(SalesOrder_CreateInput _data, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Post, $"sales-order")
            {
                Content = new StringContent(JsonSerializer.Serialize(_data), Encoding.UTF8, "application/json")
            };
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output<SalesOrder_CreateOutput>>(content, SerializerOptions);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<Output<SalesOrder_UpdateOutput>> UpdateAsync(int _salesOrderId, SalesOrder_UpdateInput_Data _data, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Put, $"sales-order/{ _salesOrderId }")
            {
                Content = new StringContent(JsonSerializer.Serialize(_data), Encoding.UTF8, "application/json")
            };
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output<SalesOrder_UpdateOutput>>(content, SerializerOptions);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<Output> DeleteAsync(int _salesOrderId, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Delete, $"sales-order/{ _salesOrderId }");
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output>(content, SerializerOptions);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<Output<ICollection<SalesOrder_ReadListOutput>>> ReadListAsync(SalesOrder_ReadListInput_Criteria _criteria, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, $"sales-order?{ ToQueryString(_criteria) }");
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output<ICollection<SalesOrder_ReadListOutput>>>(content, SerializerOptions);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<Output<SalesOrderDetail_ReadOutput>> Detail_ReadAsync(int _salesOrderDetailId, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, $"sales-order/detail/{ _salesOrderDetailId }");
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output<SalesOrderDetail_ReadOutput>>(content, SerializerOptions);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<Output<SalesOrderDetail_CreateOutput>> Detail_CreateAsync(int _salesOrderId, SalesOrderDetail_CreateInput_Data _data, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Post, $"sales-order/{ _salesOrderId }/detail")
            {
                Content = new StringContent(JsonSerializer.Serialize(_data), Encoding.UTF8, "application/json")
            };
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output<SalesOrderDetail_CreateOutput>>(content, SerializerOptions);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<Output> Detail_UpdateAsync(int _salesOrderDetailId, SalesOrderDetail_UpdateInput_Data _data, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Put, $"sales-order/detail/{ _salesOrderDetailId }")
            {
                Content = new StringContent(JsonSerializer.Serialize(_data), Encoding.UTF8, "application/json")
            };
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output>(content, SerializerOptions);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<Output> Detail_DeleteAsync(int _salesOrderDetailId, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Delete, $"sales-order/detail/{ _salesOrderDetailId }");
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output>(content, SerializerOptions);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<Output<ICollection<SalesOrderDetail_ReadListOutput>>> Detail_ReadListAsync(int _salesOrderId, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, $"sales-order/{ _salesOrderId }/detail");
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output<ICollection<SalesOrderDetail_ReadListOutput>>>(content, SerializerOptions);
            }
        }
    }
}