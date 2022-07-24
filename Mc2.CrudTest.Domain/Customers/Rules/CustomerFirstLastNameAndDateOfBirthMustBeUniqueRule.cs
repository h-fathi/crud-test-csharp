using Mc2.CrudTest.Shared.Domain;
using System;

namespace Mc2.CrudTest.Domain.Customers.Rules
{
    public class CustomerFirstLastNameAndDateOfBirthMustBeUniqueRule : IBusinessRule
    {

        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
        private readonly Guid? _customerId;
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly DateTime _dateOfBirth;

        public CustomerFirstLastNameAndDateOfBirthMustBeUniqueRule(ICustomerUniquenessChecker customerUniquenessChecker,
           string firstName, string lastName, DateTime dateOfBirth, Guid? customerId)
        {
            _customerUniquenessChecker = customerUniquenessChecker;
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
            _customerId = customerId;
        }

        public string Message => "Customer with this FirstName and LastName and Date Of Birth already exists.";

        public bool IsBroken() => ! _customerUniquenessChecker.CustomerFirstLastNameAndBirthOfDateMustBeUnique(_firstName, _lastName, _dateOfBirth, _customerId).GetAwaiter().GetResult();

    }
}
