using System;
using MediatR;

namespace Mc2.CrudTest.Shared.Domain
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}