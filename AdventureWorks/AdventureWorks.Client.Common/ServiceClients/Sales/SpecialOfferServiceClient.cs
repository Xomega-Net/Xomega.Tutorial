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
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Common
{
    ///<summary>
    /// Sale discounts lookup table.
    ///</summary>
    public class SpecialOfferServiceClient : HttpServiceClient, ISpecialOfferService
    {
        protected readonly JsonSerializerOptions SerializerOptions;

        public SpecialOfferServiceClient(HttpClient httpClient, IOptionsMonitor<JsonSerializerOptions> options, ResourceManager resourceManager)
            : base(httpClient, resourceManager)
        {
            SerializerOptions = options.CurrentValue;
        }

        /// <inheritdoc/>
        public virtual async Task<Output<ICollection<SpecialOffer_ReadEnumOutput>>> ReadEnumAsync(CancellationToken token = default)
        {
            HttpRequestMessage msg = new (HttpMethod.Get, $"special-offer/enum");
            using var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token);
            var content = await ReadOutputContentAsync(resp);
            return await JsonSerializer.DeserializeAsync<Output<ICollection<SpecialOffer_ReadEnumOutput>>>(content, SerializerOptions, token);
        }
    }
}