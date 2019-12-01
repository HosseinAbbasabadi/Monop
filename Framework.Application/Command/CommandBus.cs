using Framework.Core;

namespace Framework.Application.Command
{
    public class CommandBus : ICommandBus
    {
        public void Dispatch<T>(T command) where T : ICommand
        {
            var handler = ServiceLocator.Current.Resolve<ITransactionalCommandHandlerDecorator<T>>();
            handler.Handle(command);
            ServiceLocator.Current.Release(handler);
        }
    }
}
