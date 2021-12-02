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
    /// Cross-reference table mapping customers, vendors, and employees to their addresses.
    ///</summary>
    public class BusinessEntityAddressServiceClient : HttpServiceClient, IBusinessEntityAddressService
    {
        protected readonly JsonSerializerOptions SerializerOptions;

        public BusinessEntityAddressServiceClient(HttpClient httpClient, IOptionsMonitor<JsonSerializerOptions> options)
            : base(httpClient)
        {
            SerializerOptions = options.CurrentValue;
        }

        /// <inheritdoc/>
        public virtual async Task<Output<ICollection<BusinessEntityAddress_ReadListOutput>>> ReadListAsync(int _businessEntityId, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, $"business-entity/{ _businessEntityId }/address");
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output<ICollection<BusinessEntityAddress_ReadListOutput>>>(content, SerializerOptions);
            }
        }
    }
}