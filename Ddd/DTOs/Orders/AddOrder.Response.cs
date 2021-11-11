using System.Collections.Generic;
using Ddd.Core.Domain.Order;
using System;

namespace Ddd.DTOs.Orders
{
	public class AddOrderResponse
	{
		public int Id { get; set; }
		public string CustomerName { get; set; }
		public DateTime CreatedDate { get; set; }
		public string OrderStatus { get; set; }
		public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
