using System.Collections.Generic;

namespace Ddd.Core.Domain.Order
{
    public interface IOrder
    {
        public IEnumerable<OrderItem> GetOrderItems();
        public void AddOrderItem(string itemName);
        public void UpdateOrderItem(OrderItem orderItem);
        public void DeleteOrderItem(OrderItem orderItem);
    }
}
