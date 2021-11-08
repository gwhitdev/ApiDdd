using System;
using System.Collections.Generic;
using Ddd.Core.Domain.Order;

namespace Ddd.DTOs.Orders
{
    public class GetOrderResponse
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
