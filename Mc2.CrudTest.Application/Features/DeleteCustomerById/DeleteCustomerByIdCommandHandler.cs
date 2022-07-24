using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Shared.Data;
using MediatR;

namespace Mc2.CrudTest.Application.Features.DeleteCustomerById
{
    public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerByIdCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            var customerId = new CustomerId(request.CustomerId);
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null) return false;

            //let's remove it
             _customerRepository.Delete(customerId);
            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }
    }
}