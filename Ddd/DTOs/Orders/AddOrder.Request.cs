using Ddd.Core.Domain.Order;
using System;

namespace Ddd.DTOs.Orders
{
    public class AddOrderRequest
    {
        public string CustomerName { get; set; }
        public string OrderStatus { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}
