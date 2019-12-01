using System;
using Castle.Windsor;
using Framework.Castle;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketManagement.Infrastructure.Configuration;

namespace TicketManagement.Presentation.Rest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("MonopDb");
            var container = new WindsorContainer();

            WireupBoundedContexts(container, connectionString);
            WireupInternalServices(services);

            return new WindsorServiceResolver(services, container).GetServiceProvider();
        }

        private static void WireupInternalServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private static void WireupBoundedContexts(WindsorContainer container, string connectionString)
        {
            TicketManagementBootstrapper.Config(container, connectionString);
            FrameworkBootstrapper.WireUp(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}