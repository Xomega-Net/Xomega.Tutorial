using AdventureWorks.Services.Common;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Json;
using System.Resources;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Client;
using Xomega.Framework.Services;

namespace AdventureWorks.Client.Common
{
    /// <summary>
    /// Implementation of IPasswordLoginService that uses REST API for cookie-based authentication.
    /// </summary>
    public class CookieLoginServiceClient : PasswordLoginServiceClient
    {
        private readonly IPrincipalConverter<UserInfo> principalConverter;
        private readonly IPrincipalProvider principalProvider;

        public CookieLoginServiceClient(IHttpClientFactory httpClientFactory, RestApiConfig apiConfig,
            IOptionsMonitor<JsonSerializerOptions> serializerOptions, ResourceManager resourceManager,
            IPrincipalConverter<UserInfo> principalConverter, IPrincipalProvider principalProvider)
            : base(httpClientFactory, apiConfig, serializerOptions, resourceManager)
        {
            this.principalConverter = principalConverter;
            this.principalProvider = principalProvider;
        }

        public override async Task<Output<UserInfo>> LoginAsync(PasswordCredentials _credentials, CancellationToken token = default)
        {
            using (var resp = await Http.PostAsync("auth/cookie", new StringContent(
                JsonSerializer.Serialize(_credentials, SerializerOptions), Encoding.UTF8, "application/json")))
            {
                var res = await resp.Content.ReadFromJsonAsync<Output<UserInfo>>(token);
                if (res.Result != null)
                    principalProvider.CurrentPrincipal = principalConverter.ToPrincipal(res.Result);
                return res;
            }
        }
    }
}
