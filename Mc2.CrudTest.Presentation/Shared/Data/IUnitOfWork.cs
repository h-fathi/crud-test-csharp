using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Shared.Data
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
