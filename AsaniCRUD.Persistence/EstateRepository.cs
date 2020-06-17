using System.Threading.Tasks;
using AsaniCRUD.Domain;
using NHibernate;

namespace AsaniCRUD.Persistence
{
    public class EstateRepository : IEstateRepository
    {
        private readonly ISession _session;
        private const string SequenceName = "EstateSeq";

        public EstateRepository(ISession session)
        {
            _session = session;
        }

        public async Task<long> GetNextId()
        {
            var id = await _session.CreateSQLQuery($"SELECT NEXT VALUE FOR {SequenceName}").UniqueResultAsync<long>();
            return id;
        }

        public async Task Create(Estate entity)
        {
            await _session.SaveAsync(entity);
        }

        public async Task<Estate> GetBy(long id)
        {
            return await _session.GetAsync<Estate>(id);
        }

        public async Task Delete(Estate entity)
        {
            await _session.DeleteAsync(entity);
        }
    }
}
