using Mc2.CrudTest.Domain.Customers;
using System;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.DomainServices
{
    public class CustomerUniquenessChecker : ICustomerUniquenessChecker
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerUniquenessChecker(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<bool> CustomerFirstLastNameAndBirthOfDateMustBeUnique(string customerFirstName, string customerLastName, DateTime dateOfBirth, Guid? id = null)
        {
            return _customerRepository.ExistCustomerFirstLastNameAndBirthOfDate(customerFirstName, customerLastName, dateOfBirth, id);
        }

        public Task<bool> CustomerEmailMustBeUnique(string email, Guid? id = null)
        {
            return _customerRepository.ExistCustomerEmail(email, id);
        }
    }
}