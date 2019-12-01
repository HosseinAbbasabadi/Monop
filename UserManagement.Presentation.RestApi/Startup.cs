using System;
using Castle.Windsor;
using Framework.Castle;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Infrastructure.Config;

namespace UserManagement.Presentation.RestApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("ExchangeServiceDB");
            var container = new WindsorContainer();

            WireupBoundedContexts(container, connectionString);
            WireupInternalServices(services);

            return new WindsorServiceResolver(services, container).GetServiceProvider();
        }

        private static void WireupInternalServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddTransient<IResourceOwnerPasswordValidator, UserAuthenticationValidator>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var identityServerConfiguration = new Config();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(identityServerConfiguration.ApiResources())
                .AddInMemoryClients(identityServerConfiguration.Clients())
                .AddInMemoryIdentityResources(identityServerConfiguration.IdentityResources());
        }

        private static void WireupBoundedContexts(WindsorContainer container, string connectionString)
        {
            UserManagementBootstrapper.Wireup(container, connectionString);
            FrameworkBootstrapper.WireUp(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseMvc();
        }
    }
}