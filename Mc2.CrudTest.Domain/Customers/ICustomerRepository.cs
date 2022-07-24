using System;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Customers
{
    public interface ICustomerRepository
    {    
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task<Customer> GetByIdAsync(CustomerId id);
        void Delete(CustomerId id);

        Task<bool> ExistCustomerEmail(string email, Guid? id = null);
        Task<bool> ExistCustomerFirstLastNameAndBirthOfDate(string customerFirstName, string customerLastName, DateTime dateOfBirth, Guid? id = null);
    }
}