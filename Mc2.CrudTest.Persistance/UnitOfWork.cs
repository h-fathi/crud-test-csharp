using Mc2.CrudTest.Persistance.Contexts;
using Mc2.CrudTest.Shared.Data;
using Mc2.CrudTest.Shared.Dispatching;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;
        public UnitOfWork(ApplicationDbContext dbContext, IDomainEventsDispatcher domainEventsDispatcher)
        {
            _dbContext = dbContext;
            _domainEventsDispatcher = domainEventsDispatcher;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {

            await this._domainEventsDispatcher.DispatchEventsAsync();
            return await this._dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
