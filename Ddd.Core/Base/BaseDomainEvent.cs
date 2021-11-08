using System;
using MediatR;

namespace Ddd.Core.Base
{
    public class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; private set; } = DateTime.UtcNow;
    }
}
