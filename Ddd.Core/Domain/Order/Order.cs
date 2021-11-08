using System;
using System.Collections.Generic;
using System.Linq;
using Ddd.Core.Base;
using Ddd.Core.Domain.Order.Events;

namespace Ddd.Core.Domain.Order
{
    public class Order : BaseEntity
    {
        public string CustomerName { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string OrderStatus { get; private set; }

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        private List<OrderItem> _orderItems = new List<OrderItem>();

        public Order(string customerName, string orderStatus, List<OrderItem> orderItems)
        {
            CustomerName = customerName;
            OrderStatus = orderStatus;
            CreatedDate = DateTime.UtcNow;
            _orderItems = orderItems;
            var newOrderAddedEvent = new NewOrderAddedEvent(this);
            Events.Add(newOrderAddedEvent);
        }
        private Order(){}

        public void AddOrderItem(string itemName)
        {
            _orderItems.Add(new OrderItem(itemName));
            
        }

        public IEnumerable<OrderItem> GetOrderItems()
        {
            return OrderItems;    
        }
    }
}
