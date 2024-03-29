﻿using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Framework.Application.Command;
using Framework.Application.Query;
using Framework.Configuration;
using Framework.Core;
using Framework.Identity;
using Framework.Testing.Hosting.Core;
using Framework.Testing.Hosting.NetCoreHosting;
using Microsoft.AspNetCore.Http;

namespace Framework.Castle
{
    public static class FrameworkBootstrapper
    {
        public static void WireUp(IWindsorContainer container)
        {
            ServiceLocator.SetCurrent(new WindsorServiceLocator(container));

            //container.Register(Component.For<SecurityInterceptor>().LifestyleSingleton());

            container.Register(Component.For(typeof(IExceptionLoggerCommandHandlerDecorator<>))
                .ImplementedBy(typeof(ExceptionExceptionLoggerCommandHandlerDecorator<>)).LifestyleScoped());

            container.Register(Component.For(typeof(ITransactionalCommandHandlerDecorator<>))
                .ImplementedBy(typeof(TransactionalCommandHandlerDecorator<>)).LifestyleScoped());

            //container.Register(Component.For<IFrameworkLoggerService>()
            //    .ImplementedBy<FrameworkLoggerService>().LifestyleScoped());

            container.Register(
                Component.For<ICommandBus>().ImplementedBy<ScoppedCommandBusDecorator>().LifestyleSingleton(),
                Component.For<ICommandBus>().ImplementedBy<CommandBus>().LifestyleSingleton());

            container.Register(
                Component.For<IQueryBus>().ImplementedBy<ScoppedQuerydBusDecorator>().LifestyleSingleton(),
                Component.For<IQueryBus>().ImplementedBy<QueryBus>().LifestyleSingleton());

            container.Register(Component.For<IHttpContextAccessor>().ImplementedBy<HttpContextAccessor>()
                .LifestyleSingleton());

            container.Register(Component.For<IClaimHelper>().ImplementedBy<ClaimHelper>().LifestyleSingleton());

            container.Register(Component.For<IPasswordHasher>().ImplementedBy<PasswordHasher>().LifestyleSingleton());

            //var path = AppDomain.CurrentDomain.BaseDirectory + @"bin\";
            //container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(path))
            //    .BasedOn<IPermissionExposer>().WithService.FromInterface());
            //container.Register(Component.For<IPermissionExposer>().ImplementedBy<ForumPermissionExposer>()
            //    .LifestyleSingleton());

            container.Register(Component.For<IFrameworkConfiguration>().ImplementedBy<FrameworkConfiguration>()
                .LifestyleSingleton());

            container.Register(Component.For<IService>().LifestyleScoped());
        }
    }
}