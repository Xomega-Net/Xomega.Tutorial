using AdventureWorks.Services.Common;
using AdventureWorks.Services.Common.Enumerations;
using AdventureWorks.Services.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
#if !EF6
using Microsoft.EntityFrameworkCore;
#endif
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Resources;
using Xomega.Framework;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Rest
{
    public class Startup
    {
        public const string ConfigConnectionString = "add:AdventureWorksEntities:connectionString";

        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        public void Configure(IApplicationBuilder app)
        {
            // configure global exception handling using Xomega Framework
            app.UseExceptionHandler(ErrorController.DefaultPath);
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // ASP.NET configuration
            services.AddCors();
            services.AddHttpContextAccessor();
            ConfigureAuth(services);
            services.AddControllers(o => o.Filters.Add(new AuthorizeFilter()));

            // framework services configuration
            services.AddErrors(env.IsDevelopment());
            services.AddSingletonLookupCacheProvider();
            services.AddOperators();
            services.AddTransient<IPrincipalProvider, ContextPrincipalProvider>();

            // app services configuration
            services.AddSingleton<ResourceManager>(sp => new CompositeResourceManager(
                Messages.ResourceManager,
                AdventureWorks.Services.Entities.Messages.ResourceManager,
                Xomega.Framework.AspNetCore.Messages.ResourceManager,
                Xomega.Framework.Messages.ResourceManager));
            string connStr = configuration.GetValue<string>(ConfigConnectionString);
#if EF6
            services.AddScoped(sp => new AdventureWorksEntities(connStr));
#else
            services.AddDbContext<AdventureWorksEntities>(opt => opt
                .UseLazyLoadingProxies()
                .UseSqlServer(connStr));
#endif
            services.AddServiceImplementations();
            services.AddLookupCacheLoaders();
            services.AddXmlResourceCacheLoader(typeof(Operators).Assembly, ".enumerations.xres", true);

            // TODO: configure other services as needed
        }

        public void ConfigureAuth(IServiceCollection services)
        {
            // configure jwt authentication
            var jwtOptions = services.AddAuthConfig(configuration);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = jwtOptions.ValidationParameters;
            });
        }
    }
}
