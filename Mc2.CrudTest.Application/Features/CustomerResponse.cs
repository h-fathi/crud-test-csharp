using System;

namespace Mc2.CrudTest.Application.Features
{
    /// <summary>
    ///  Customer Response
    /// </summary>
    public class CustomerResponse
    {
        public Guid Id { get; }
        public string Firstname { get; }
        public string Lastname { get; }
        public DateTime DateOfBirth { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string BankAccountNumber { get; }
    }
}
