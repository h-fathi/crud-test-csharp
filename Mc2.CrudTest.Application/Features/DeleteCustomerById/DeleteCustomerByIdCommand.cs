using MediatR;
using System;


namespace Mc2.CrudTest.Application.Features.DeleteCustomerById
{
    public class DeleteCustomerByIdCommand : IRequest<bool>
    {
        public DeleteCustomerByIdCommand(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; }
    }
}