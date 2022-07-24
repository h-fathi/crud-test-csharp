using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Shared.Data;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Features.UpdateCustomer.RegisterCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, ICustomerUniquenessChecker customerUniquenessChecker, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _customerUniquenessChecker = customerUniquenessChecker;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.CreateUpdated(request.Id, request.FirstName, request.LastName,
                request.DateOfBirth, request.PhoneNumber, request.Email, request.BankAccountNumber, 
                this._customerUniquenessChecker);


            await this._customerRepository.UpdateAsync(customer);
            await this._unitOfWork.CommitAsync(cancellationToken);

            return true;
        }

    }

}
