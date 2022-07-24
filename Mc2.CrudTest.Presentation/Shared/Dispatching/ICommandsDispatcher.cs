using System;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Shared.Dispatching
{
    public interface ICommandsDispatcher
    {
        Task DispatchCommandAsync(Guid id);
    }
}
