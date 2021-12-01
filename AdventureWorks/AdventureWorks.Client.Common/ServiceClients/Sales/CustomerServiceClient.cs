//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "REST Service Clients" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Common
{
    ///<summary>
    /// Current customer information. Also see the Person and Store tables.
    ///</summary>
    public class CustomerServiceClient : HttpServiceClient, ICustomerService
    {
        protected readonly JsonSerializerOptions SerializerOptions;

        public CustomerServiceClient(HttpClient httpClient, IOptionsMonitor<JsonSerializerOptions> options)
            : base(httpClient)
        {
            SerializerOptions = options.CurrentValue;
        }

        /// <inheritdoc/>
        public virtual async Task<Output<ICollection<Customer_ReadListOutput>>> ReadListAsync(Customer_ReadListInput_Criteria _criteria, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, $"customer?{ ToQueryString(_criteria) }");
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output<ICollection<Customer_ReadListOutput>>>(content, SerializerOptions);
            }
        }
    }
}