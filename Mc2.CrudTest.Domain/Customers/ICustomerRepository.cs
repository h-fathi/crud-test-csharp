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
    }
}