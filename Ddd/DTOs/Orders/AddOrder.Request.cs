using Ddd.Core.Domain.Order;
using System.Collections.Generic;

namespace Ddd.DTOs.Orders
{
    public class AddOrderRequest
    {
        public string CustomerName { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
