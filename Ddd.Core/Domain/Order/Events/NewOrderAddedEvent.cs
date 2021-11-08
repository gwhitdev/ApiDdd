using System;
using Ddd.Core.Base;

namespace Ddd.Core.Domain.Order.Events
{
    public class NewOrderAddedEvent : BaseDomainEvent
    {
        public Order Order { get; set; }
        public NewOrderAddedEvent(Order order)
        {
            Order = order;
        }


    }
}
