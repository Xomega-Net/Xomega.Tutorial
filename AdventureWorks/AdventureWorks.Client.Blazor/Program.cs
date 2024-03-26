using AdventureWorks.Client.Blazor;
using AdventureWorks.Client.Blazor.Common;
using AdventureWorks.Client.Blazor.Common.Views;
using AdventureWorks.Client.Common.DataObjects;
using AdventureWorks.Client.Common.ViewModels;
using AdventureWorks.Services.Common;
using AdventureWorks.Services.Common.Enumerations;
using AdventureWorks.Services.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Resources;
using Xomega.Framework;
using Xomega.Framework.Client;
using Xomega.Framework.Services;
using static AdventureWorks.Client.Blazor.Common.UrlConfig;

Routes.AdditionalAssemblies = [typeof(Program).Assembly];

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddXmlFile("db.config", optional: false, reloadOnChange: false);

// Auth configuration
string apiPath = builder.Configuration.GetValue<string>("RestAPI:Path");

Func<RedirectContext<CookieAuthenticationOptions>, int, Task> apiAwareRedirect = (ctx, status) =>
{
    var pfx = new PathString("/" + apiPath?.TrimStart('/'));
    if (ctx.Request.Path.StartsWithSegments(pfx))
    {
        ctx.Response.Headers.Location = ctx.RedirectUri;
        ctx.Response.StatusCode = status;
    }
    else ctx.Response.Redirect(ctx.RedirectUri);
    return Task.CompletedTask;
};
services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(opts =>
{
    opts.LoginPath = LoginUrl;
    opts.ReturnUrlParameter = ReturnUrlParam;
    opts.AccessDeniedPath = UnauthorizedUrl;
    opts.Events.OnRedirectToLogin = ctx => apiAwareRedirect(ctx, 401);
    opts.Events.OnRedirectToAccessDenied = ctx => apiAwareRedirect(ctx, 403);
});
services.AddAuthorization(o => o.AddAppPolicies());
services.AddCascadingAuthenticationState();
services.AddScoped<IPrincipalConverter<UserInfo>, UserInfoPrincipalConverter>();
services.AddScoped<AuthenticationStateProvider, PersistingAuthStateProvider<UserInfo>>();
services.AddTransient<IPrincipalProvider, ContextPrincipalProvider>();
services.AddHttpContextAccessor();
services.AddScoped<SignInManager>();
services.AddScoped<ILoginNavigation, ServerLoginNavigation>();

services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
services.AddControllers(o =>
{
    o.Filters.Add(new AuthorizeFilter());
    o.UseGeneralRoutePrefix(apiPath);
})
.ConfigureApiBehaviorOptions(o =>
{
    o.SuppressModelStateInvalidFilter = true;
});

// Xomega Framework configuration
services.AddErrors(builder.Environment.IsDevelopment());
services.AddSingletonLookupCacheProvider();
services.AddXmlResourceCacheLoader(typeof(Operators).Assembly, ".enumerations.xres", false);
services.AddOperators();

// App services configuration
services.AddSingleton<ResourceManager>(sp => new CompositeResourceManager(
    AdventureWorks.Client.Common.Messages.ResourceManager,
    AdventureWorks.Client.Common.Labels.ResourceManager,
    AdventureWorks.Services.Entities.Messages.ResourceManager,
    Xomega.Framework.Messages.ResourceManager));
string connStr = builder.Configuration.GetValue<string>("add:AdventureWorksEntities:connectionString");
services.AddDbContext<AdventureWorksEntities>(opt => opt.UseLazyLoadingProxies().UseSqlServer(connStr));
services.AddServiceImplementations();
services.AddDataObjects();
services.AddViewModels();
services.AddLookupCacheLoaders();
services.AddSingleton<MainMenu>();

// Build and configure the app
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.AddSignIn();
app.AddSignOut();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();

app.Run();