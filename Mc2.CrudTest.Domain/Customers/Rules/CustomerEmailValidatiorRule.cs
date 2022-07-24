using Mc2.CrudTest.Shared.Domain;
using System;

namespace Mc2.CrudTest.Domain.Customers.Rules
{
    public class CustomerEmailUniqueValidatiorRule : IBusinessRule
    {
        private readonly Guid? _customerId;
        private readonly string _email;
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
        public CustomerEmailUniqueValidatiorRule(ICustomerUniquenessChecker customerUniquenessChecker, string email, Guid? id)
        {
            _customerId = id;
            _email = email;
            _customerUniquenessChecker = customerUniquenessChecker;
        }

        public string Message => "Email already exists";

        public bool IsBroken() => !_customerUniquenessChecker.CustomerEmailMustBeUnique(_email, _customerId).GetAwaiter().GetResult();
    }
}
