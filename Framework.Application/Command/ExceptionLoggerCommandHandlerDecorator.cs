using System;

namespace Framework.Application.Command
{
    public class ExceptionExceptionLoggerCommandHandlerDecorator<T> : IExceptionLoggerCommandHandlerDecorator<T>,
        ITransactionalCommandHandlerDecorator<T>
        where T : ICommand
    {
        private readonly ITransactionalCommandHandlerDecorator<T> _transactionalCommandHandler;

        public ExceptionExceptionLoggerCommandHandlerDecorator(ITransactionalCommandHandlerDecorator<T> transactionalCommandHandler)
        {
            _transactionalCommandHandler = transactionalCommandHandler;
        }

        public void Handle(T command)
        {
            try
            {
                _transactionalCommandHandler.Handle(command);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
    }
}