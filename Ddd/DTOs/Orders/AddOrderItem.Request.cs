using System;
using Ddd.Core.Domain.Order;

namespace Ddd.DTOs.Orders
{
    public class AddOrderItemRequest
    {
        public int OrderId { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}
