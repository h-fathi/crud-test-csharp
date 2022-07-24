using Mc2.CrudTest.Domain.Customers;
using MediatR;
using System;

namespace Mc2.CrudTest.Application.Features.RegisterCustomer
{
    public class RegisterCustomerCommand : IRequest<CustomerId>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string BankAccountNumber { get; }

        public RegisterCustomerCommand(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }
    }
}
