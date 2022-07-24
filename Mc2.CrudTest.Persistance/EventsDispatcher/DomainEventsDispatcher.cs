using System.Linq;
using System.Threading.Tasks;
using Mc2.CrudTest.Persistance.Contexts;
using Mc2.CrudTest.Shared.Dispatching;
using Mc2.CrudTest.Shared.Domain;
using MediatR;

namespace Mc2.CrudTest.Persistance
{
    public class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _applicationContext;

        public DomainEventsDispatcher(IMediator mediator, ApplicationDbContext applicationContext)
        {
            this._mediator = mediator;
            this._applicationContext = applicationContext;
        }

        public async Task DispatchEventsAsync()
        {
            var domainEntities = this._applicationContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await _mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);


        }
    }
}