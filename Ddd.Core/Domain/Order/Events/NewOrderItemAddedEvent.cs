using Ddd.Core.Base;

namespace Ddd.Core.Domain.Order.Events
{
    public class NewOrderItemAddedEvent : BaseDomainEvent
    {
        public Order Order { get; private set; }
        public NewOrderItemAddedEvent(Order order)
        {
            Order = order;
        }
    }
}
