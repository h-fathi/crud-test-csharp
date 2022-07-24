using Mc2.CrudTest.Shared.Domain;

namespace Mc2.CrudTest.Domain.Customers.Rules
{
    public class CustomerPhoneNumberValidatiorRule : IBusinessRule
    {
        private readonly string _phoneNumber;

        public CustomerPhoneNumberValidatiorRule(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        public bool CheckPhoneNumber()
        {
            var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
            try
            {
                var check = phoneNumberUtil.Parse(_phoneNumber, null);

                if (phoneNumberUtil.IsValidNumber(check))
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public string Message => "Phone Number Is Invalid";

        public bool IsBroken() => !CheckPhoneNumber();
    }
}
