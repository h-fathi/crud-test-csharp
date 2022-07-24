using Mc2.CrudTest.Shared.Domain;
using System;

namespace Mc2.CrudTest.Domain.Customers
{
    public class CustomerId : TypedIdValueBase
    {
        public CustomerId(Guid value) : base(value)
        {
        }
    }
}
