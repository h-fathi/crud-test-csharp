using Mc2.CrudTest.Shared.Domain;
using System;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        private string _email;

        private Email(String email)
        {
            if (!ValidateEmail(email))
                throw new ArgumentException("Email is not valid.");
            this._email = email;
        }

        static public Email Create(string email)
        {
            return new Email(email);
        }

        static public Boolean ValidateEmail(string email)
        {
            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
               + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
               + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
               + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
               + @"[a-zA-Z]{2,}))$";
            Regex regexStrict = new Regex(patternStrict);
            return regexStrict.IsMatch(email);
        }

        public string Value
        {
            get { return _email; }
        }
        public override string ToString()
        {
            return _email;
        }
    }
}
