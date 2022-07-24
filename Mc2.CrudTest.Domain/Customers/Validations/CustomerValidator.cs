using FluentValidation;

namespace Mc2.CrudTest.Domain.Customers.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(X => X.Firstname)
                .NotEmpty()
                .NotNull();

            RuleFor(X => X.Lastname)
                .NotEmpty()
                .NotNull();

            RuleFor(X => X.DateOfBirth)
                .NotNull();


            RuleFor(X => X.PhoneNumber)
                .NotEmpty()
                .NotNull();

            RuleFor(X => X.BankAccountNumber)
                .NotEmpty()
                .NotNull();
        }


    }
}
