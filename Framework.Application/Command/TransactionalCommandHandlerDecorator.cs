using System;
using Framework.Core;

namespace Framework.Application.Command
{
    public class TransactionalCommandHandlerDecorator<T> : ITransactionalCommandHandlerDecorator<T>, ICommandHandler<T>
        where T : ICommand
    {
        private readonly ICommandHandler<T> _commandHandler;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionalCommandHandlerDecorator(ICommandHandler<T> commandHandler, IUnitOfWork unitOfWork)
        {
            _commandHandler = commandHandler;
            _unitOfWork = unitOfWork;
        }

        public void Handle(T command)
        {
            try
            {
                _unitOfWork.Begin();
                _commandHandler.Handle(command);
                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                _unitOfWork.Rollback();
                Console.WriteLine(exception.Message);
                throw;
            }
        }
    }
}