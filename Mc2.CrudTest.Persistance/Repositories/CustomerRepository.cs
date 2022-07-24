using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistance.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext)); ;
        }

        public async Task AddAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer.GetState());

        }

        public async Task UpdateAsync(Customer customer)
        {
            if (customer.Id is null)
                throw new ArgumentNullException(nameof(customer.Id));

            var item = await _dbContext.Customers.AsQueryable().Where(x => x.Id == customer.Id.Value).SingleOrDefaultAsync();

            if (item == null)
                throw new Exception("Customer Not Found.");

            item.Lastname = customer.Lastname;
            item.Email = customer.Email.Value;
            item.Firstname = customer.Firstname;
            item.DateOfBirth = customer.DateOfBirth;
            item.PhoneNumber = customer.PhoneNumber;

            _dbContext.Customers.Update(item);

        }

        public async Task<Customer> GetByIdAsync(CustomerId id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            var item = await _dbContext.Customers.AsQueryable().Where(x => x.Id == id.Value).FirstOrDefaultAsync();

            if (item == null)
                throw new Exception("Customer Not Found.");

            return new Customer(item.Id, item.Firstname, item.Lastname, item.DateOfBirth, item.PhoneNumber, item.Email, item.BankAccountNumber);
        }

        public void Delete(CustomerId id)
        {
            if (id is null)
                throw new ArgumentNullException(nameof(id));

            var item = _dbContext.Customers.AsQueryable().Where(x => x.Id == id.Value).FirstOrDefault();

            if (item == null)
                throw new Exception("Customer Not Found.");

            _dbContext.Customers.Remove(item);
        }

    }
}
