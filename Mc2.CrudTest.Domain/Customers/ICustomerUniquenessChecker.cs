using System;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Customers
{
    public interface ICustomerUniquenessChecker
    {
        Task<bool> CustomerFirstLastNameAndBirthOfDateMustBeUnique(string customerFirstName, string customerLastName, DateTime dateOfBirth, Guid? id = null);
        Task<bool> CustomerEmailMustBeUnique(string email, Guid? id = null);
    }
}