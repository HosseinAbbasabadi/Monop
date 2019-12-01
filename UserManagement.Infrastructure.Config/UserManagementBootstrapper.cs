using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Framework.Nhibernate;
using NHibernate;
using UserManagement.Application;
using UserManagement.Persistence;
using UserManagement.Persistence.Mapping;

namespace UserManagement.Infrastructure.Config
{
    public static class UserManagementBootstrapper
    {
        public static void Wireup(WindsorContainer container, string connectionString)
        {
            const string boundedContextName = "UserManagement";
            const string sessionFactoryName = boundedContextName + "_SessionFactory";
            const string sessionName = boundedContextName + "_Session";

            container.Register(Component.For<IUserManagementRepository>().ImplementedBy<UserManagementRepository>()
                .LifestyleTransient());

            container.Register(Component.For<IUserManagementApplication>().ImplementedBy<UserManagementApplication>()
                .LifestyleTransient());

            container.Register(Component.For<ISessionFactory>().UsingFactoryMethod(a => new SessionFactoryBuilder()
                    .CreateByConnectionStringName(connectionString, typeof(UserMapping).Assembly))
                .Named(sessionFactoryName).LifestyleSingleton());

            container.Register(Component.For<ISession>().UsingFactoryMethod(a =>
            {
                var factory = a.Resolve<ISessionFactory>();
                return factory.OpenSession();
            }).LifestyleTransient().Named(sessionName));
        }
    }
}