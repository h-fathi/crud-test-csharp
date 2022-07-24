using Mc2.CrudTest.Domain.Customers.Events;
using Mc2.CrudTest.Domain.Customers.Rules;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Domain;
using System;

namespace Mc2.CrudTest.Domain.Customers
{
    public class Customer : Entity, IAggregateRoot
    {
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

            this.AddDomainEvent(new CustomerRegisteredEvent(this));
        }


        public static Customer CreateRegistered(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber,
       string email, string bankAccountNumber, ICustomerUniquenessChecker customerUniquenessChecker)
        {
            CheckRule(new CustomerEmailUniqueValidatiorRule(customerUniquenessChecker, email, null));
            CheckRule(new CustomerPhoneNumberValidatiorRule(phoneNumber));
            CheckRule(new CustomerFirstLastNameAndDateOfBirthMustBeUniqueRule(customerUniquenessChecker, firstName, lastName, dateOfBirth, null));

            return new Customer(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
        }


        public static Customer CreateUpdated(Guid id, string firstName, string lastName, DateTime dateOfBirth, string phoneNumber,
         string email, string bankAccountNumber, ICustomerUniquenessChecker customerUniquenessChecker)
        {
            CheckRule(new CustomerEmailUniqueValidatiorRule(customerUniquenessChecker, email, id));
            CheckRule(new CustomerPhoneNumberValidatiorRule(phoneNumber));
            CheckRule(new CustomerFirstLastNameAndDateOfBirthMustBeUniqueRule(customerUniquenessChecker, firstName, lastName, dateOfBirth, id));

            return new Customer(id, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
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
