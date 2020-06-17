using System.Threading.Tasks;

namespace Framework.Application
{
    public interface ICommandHandler
    {

    }

    public interface ICommandHandler<in T> : ICommandHandler
    {
        Task Handle(T command);
    }
}