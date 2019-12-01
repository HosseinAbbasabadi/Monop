using System;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace TicketManagement.Presentation.Rest
{
    public class WindsorServiceResolver
    {
        private static IServiceProvider _serviceProvider;

        public WindsorServiceResolver(IServiceCollection services, IWindsorContainer container)
        {
            _serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(container, services);

        }

        public IServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }
    }
}