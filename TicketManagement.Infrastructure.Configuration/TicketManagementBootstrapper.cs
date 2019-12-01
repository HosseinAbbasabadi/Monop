using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Framework.Application.Command;
using Framework.Core;
using Framework.Nhibernate;
using Framework.Testing.Hosting.NetCoreHosting;
using NHibernate;
using TicketManagement.Application;
using TicketManagement.Domain.TicketAgg;
using TicketManagement.Infrastructure.Persisrence;
using TicketManagement.Infrastructure.Persisrence.Mappings;

namespace TicketManagement.Infrastructure.Configuration
{
    public static class TicketManagementBootstrapper
    {
        public static void Config(WindsorContainer container, string connectionString)
        {
            const string boundedContextName = "TicketManagement_";
            const string sessionFactoryName = boundedContextName + "SessionFactory";
            const string sessionName = boundedContextName + "Session";
            const string unitOfWorkName = boundedContextName + "UOW";
            const string hostingOptions = boundedContextName + "HostingOptions";

            container.Register(Classes.FromAssemblyContaining(typeof(TicketCommandHandler))
                .BasedOn(typeof(ICommandHandler<>)).WithService.AllInterfaces().LifestyleTransient());

            //container.Register(Classes.FromAssemblyContaining(typeof(DocumentQueryHandler))
            //    .BasedOn(typeof(IQueryHandler<>)).WithService.AllInterfaces().LifestyleTransient());

            //container.Register(Classes.FromAssemblyContaining(typeof(DocumentQueryHandler))
            //    .BasedOn(typeof(IQueryHandler<,>)).WithService.AllInterfaces().LifestyleTransient());

            container.Register(Component.For<ISessionFactory>().UsingFactoryMethod(a => new SessionFactoryBuilder()
                    .CreateByConnectionStringName(connectionString, typeof(TicketMapping).Assembly))
                .Named(sessionFactoryName).LifestyleSingleton());

            container.Register(Component.For<ISession>().UsingFactoryMethod(a =>
            {
                var factory = a.Resolve<ISessionFactory>();
                return factory.OpenSession();
            }).LifestyleScoped().Named(sessionName));

            container.Register(Component.For<IUnitOfWork>().ImplementedBy<NhUnitOfWork>().LifestyleBoundTo<IService>()
                .Named(unitOfWorkName));
            container.Register(Component.For<ITicketRepository>().ImplementedBy<TicketRepository>()
                .LifestyleBoundTo<IService>());

            container.Register(Component.For<DotNetCoreHostOptions>().UsingFactoryMethod(kernel =>
            {
                var options = new DotNetCoreHostOptions
                {
                    Port = 7576,
                    CsProjectPath = @"../TicketManagement.Presentation.Rest/TicketManagement.Presentation.Rest.csproj"
                };
                return options;
            }).Named(hostingOptions));
        }
    }
}