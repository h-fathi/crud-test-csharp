using Mc2.CrudTest.Shared.Domain;

namespace Mc2.CrudTest.Domain.Customers.Events
{
    public class CustomerRegisteredEvent : DomainEventBase
    {

        public Customer Customer { get; }

        public CustomerRegisteredEvent(Customer customer)
        {
            this.Customer = customer;
        }
    }
}