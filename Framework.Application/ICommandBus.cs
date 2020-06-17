using System.Threading.Tasks;
using Framework.Core;

namespace Framework.Application
{
    public interface ICommandBus
    {
        Task Dispatch<T>(T command);
    }

    public class CommandBus : ICommandBus
    {
        private readonly IServiceLocator _serviceLocator;

        public CommandBus(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task Dispatch<T>(T command)
        {
            var execute = _serviceLocator.GetInstance<ICommandHandler<T>>();
            await execute.Handle(command);
        }
    }
}
