namespace Framework.Application.Command
{
    public interface ITransactionalCommandHandlerDecorator<in T>
    {
        void Handle(T command);
    }
}