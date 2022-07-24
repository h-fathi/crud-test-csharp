using System.Threading.Tasks;

namespace Mc2.CrudTest.Shared.Dispatching
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}