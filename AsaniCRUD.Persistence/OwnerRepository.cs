using System.Threading.Tasks;
using AsaniCRUD.Domain;
using NHibernate;

namespace AsaniCRUD.Persistence
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ISession _session;
        private const string SequenceName = "OwnerSeq";

        public OwnerRepository(ISession session)
        {
            _session = session;
        }

        public async Task<long> GetNextId()
        {
            var id = await _session.CreateSQLQuery($"SELECT NEXT VALUE FOR {SequenceName}").UniqueResultAsync<long>();
            return id;
        }

        public async Task Create(Owner entity)
        {
            await _session.SaveAsync(entity);
        }

        public async Task<Owner> GetBy(long id)
        {
            return await _session.GetAsync<Owner>(id);
        }

        public async Task Delete(Owner entity)
        {
            await _session.DeleteAsync(entity);
        }
    }
}