using System.Data;
using System.Threading.Tasks;
using Framework.Core;
using NHibernate;

namespace AsaniCRUD.Persistence
{
    public class NhUnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        public NhUnitOfWork(ISession session)
        {
            _session = session;
        }

        public async Task Begin()
        {
            _session.Transaction.Begin(IsolationLevel.ReadCommitted);
        }

        public async Task Commit()
        {
            await _session.Transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _session.Transaction.RollbackAsync();
        }
    }
}
