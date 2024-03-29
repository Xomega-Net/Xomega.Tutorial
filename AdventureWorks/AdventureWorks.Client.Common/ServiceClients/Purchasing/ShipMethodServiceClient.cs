//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "REST Service Clients" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Resources;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework.Client;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Common
{
    ///<summary>
    /// Shipping company lookup table.
    ///</summary>
    public class ShipMethodServiceClient : RestApiClient, IShipMethodService
    {
        public ShipMethodServiceClient(IHttpClientFactory httpClientFactory, RestApiConfig apiConfig,
            IOptionsMonitor<JsonSerializerOptions> serializerOptions, ResourceManager resourceManager)
            : base(httpClientFactory, apiConfig, serializerOptions, resourceManager)
        {
        }

        /// <inheritdoc/>
        public virtual async Task<Output<ICollection<ShipMethod_ReadEnumOutput>>> ReadEnumAsync(CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, $"ship-method/enum");
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await ReadOutputContentAsync(resp);
                return JsonSerializer.Deserialize<Output<ICollection<ShipMethod_ReadEnumOutput>>>(content, SerializerOptions);
            }
        }
    }
}