using System.Threading.Tasks;
using Framework.Core;

namespace Framework.Application
{
    public class TransactionalCommandHandlerDecorator<T> : ICommandHandler<T> 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandHandler<T> _commandHandler;
        public TransactionalCommandHandlerDecorator(IUnitOfWork unitOfWork, ICommandHandler<T> commandHandler)
        {
            _unitOfWork = unitOfWork;
            _commandHandler = commandHandler;
        }

        public async Task Handle(T handle)
        {
            try
            {
                await _unitOfWork.Begin();
                await _commandHandler.Handle(handle);
                await _unitOfWork.Commit();
            }
            catch
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}