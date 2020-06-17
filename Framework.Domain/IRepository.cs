using System.Threading.Tasks;

namespace Framework.Domain
{
    public interface IRepository
    {
    }

    public interface IRepository<T, TKey> : IRepository where T : class
    {
        Task<TKey> GetNextId();
        Task Create(T entity);
        Task<T> GetBy(TKey id);
        Task Delete(T entity);
    }
}