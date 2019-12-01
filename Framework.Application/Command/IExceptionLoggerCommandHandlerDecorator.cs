namespace Framework.Application.Command
{
    public interface IExceptionLoggerCommandHandlerDecorator<T>
    {
        void Handle(T command);
    }
}