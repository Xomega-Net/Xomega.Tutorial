using AdventureWorks.Client.Blazor.Common;
using AdventureWorks.Client.Blazor.Common.Views;
using AdventureWorks.Client.Blazor.Wasm;
using AdventureWorks.Client.Common;
using AdventureWorks.Client.Common.DataObjects;
using AdventureWorks.Client.Common.ViewModels;
using AdventureWorks.Services.Common;
using AdventureWorks.Services.Common.Enumerations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Resources;
using Xomega.Framework;
using Xomega.Framework.Blazor;
using Xomega.Framework.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
Routes.AdditionalAssemblies = [typeof(Program).Assembly];

var services = builder.Services;

var apiConfig = builder.Configuration.GetSection("LocalApi").Get<RestApiConfig>();
if (string.IsNullOrEmpty(apiConfig.BaseAddress))
    apiConfig.BaseAddress = builder.HostEnvironment.BaseAddress;
services.AddSingleton(apiConfig);
services.AddRestServices(apiConfig);

// Auth configuration
services.AddAuthorizationCore(o => o.AddAppPolicies());
services.AddScoped<ILoginNavigation, WasmLoginNavigation>();
services.AddSingleton<IPrincipalConverter<UserInfo>, UserInfoPrincipalConverter>();
services.AddScoped<IPasswordLoginService, CookieLoginServiceClient>();
services.AddSingleton<AuthenticationStateProvider, PersistedAuthStateProvider<UserInfo>>();
services.AddSingleton(sp => sp.GetService<AuthenticationStateProvider>() as IPrincipalProvider);
services.AddCascadingAuthenticationState();

// Xomega Framework configuration
services.AddErrors(builder.HostEnvironment.IsEnvironment("Development"));
services.AddSingletonLookupCacheProvider();
services.AddXmlResourceCacheLoader(typeof(Operators).Assembly, ".enumerations.xres", false);
services.AddOperators();

// App services configuration
services.AddRestClients();
services.AddSingleton<ResourceManager>(sp => new CompositeResourceManager(
    AdventureWorks.Client.Common.Messages.ResourceManager,
    AdventureWorks.Client.Common.Labels.ResourceManager,
    Xomega.Framework.Messages.ResourceManager));
services.AddDataObjects();
services.AddViewModels();
services.AddLookupCacheLoaders();
services.AddSingleton<MainMenu>();

var host = builder.Build();

// TODO: add any custom initialization here

await host.RunAsync();
