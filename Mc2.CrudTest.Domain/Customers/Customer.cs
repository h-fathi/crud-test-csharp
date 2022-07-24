using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Domain;
using System;

namespace Mc2.CrudTest.Domain.Customers
{
    public class Customer : Entity, IAggregateRoot
    {
        public Guid Key { get { return Id.Value; } }
        public CustomerId Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; }
        public Email Email { get; private set; }



        public string BankAccountNumber { get; private set; }

        public Customer(Guid id, string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
        {
            Id = new CustomerId(id);
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = Email.Create(email);
            BankAccountNumber = bankAccountNumber;
        }
        public Customer(string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
        {
            Id = new CustomerId(Guid.NewGuid());
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = Email.Create(email);
            BankAccountNumber = bankAccountNumber;

        }

        public CustomerState GetState()
        {
            return new CustomerState
            {
                Id = this.Id.Value,
                Email = this.Email.Value,
                BankAccountNumber = this.BankAccountNumber,
                DateOfBirth = this.DateOfBirth,
                PhoneNumber = this.PhoneNumber,
                Firstname = this.Firstname,
                Lastname = this.Lastname,
            };
        }

    }
}
