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
    /// Lookup table of customer purchase reasons.
    ///</summary>
    public class SalesReasonServiceClient : HttpServiceClient, ISalesReasonService
    {
        protected readonly JsonSerializerOptions SerializerOptions;

        public SalesReasonServiceClient(HttpClient httpClient, IOptionsMonitor<JsonSerializerOptions> options)
            : base(httpClient)
        {
            SerializerOptions = options.CurrentValue;
        }

        /// <inheritdoc/>
        public virtual async Task<Output<ICollection<SalesReason_ReadListOutput>>> ReadListAsync(CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, $"sales-reason");
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output<ICollection<SalesReason_ReadListOutput>>>(content, SerializerOptions);
            }
        }
    }
}