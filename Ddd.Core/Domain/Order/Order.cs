using System;
using System.Collections.Generic;
using System.Linq;
using Ddd.Core.Base;
using Ddd.Core.Domain.Order.Events;
using Ddd.Core.Domain.Audit.Events;
using Ddd.Core.Domain.Audit;

namespace Ddd.Core.Domain.Order
{
    public class Order : BaseEntity
    {
        public string CustomerName { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string OrderStatus { get; private set; }

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        private List<OrderItem> _orderItems;

        public Order(string customerName, string orderStatus, List<OrderItem> orderItems)
        {
            CustomerName = customerName;
            OrderStatus = orderStatus;
            CreatedDate = DateTime.UtcNow;
            _orderItems = orderItems;
            var newOrderAddedEvent = new NewOrderAddedEvent(this);
            Events.Add(newOrderAddedEvent);

            
        }
        private Order()
        {
            _orderItems = new List<OrderItem>();
        }
        public void AddToAudit()
        {
            var newAuditEvent = new AddAuditEvent(new Audit.Audit("Order created", this.Id, $"{CustomerName} placed an order on {CreatedDate}"));
            Events.Add(newAuditEvent);
        }
        public void AddOrderItem(string itemName)
        {
            _orderItems.Add(new OrderItem(itemName));
            var newOrderItemAddedEvent = new NewOrderItemAddedEvent(this);
            Events.Add(newOrderItemAddedEvent);
            var newAuditEvent = new AddAuditEvent(new Audit.Audit("Order line created", this.Id, $"{CustomerName} added a line to an order on {CreatedDate}"));
            Events.Add(newAuditEvent);

        }

        public IEnumerable<OrderItem> GetOrderItems()
        {
            return OrderItems;    
        }
    }
}
