using MediatR;
using System;


namespace Mc2.CrudTest.Application.Features.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerResponse>
    {
        public GetCustomerByIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; }
    }
}