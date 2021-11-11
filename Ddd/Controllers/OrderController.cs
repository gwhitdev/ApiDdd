using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ddd.Infrastructure.Repositories;
using Ddd.Core.Domain;
using Ddd.Core.Interfaces;
using Ddd.Services.Orders;
using Microsoft.Extensions.Logging;
using Ddd.DTOs.Orders;

namespace Ddd.Controllers
{
    

    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(OrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }
        [Route("/api/orders/add")]
        [HttpPost]
        public async Task<ActionResult<AddOrderResponse>> Add([FromBody] AddOrderRequest request)
        {
            _logger.LogInformation($"ADD NEW ORDER: {request}");
            var order = await _orderService.AddNewAsync(request);
            return Created("/order/add", order);
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetOrderRequest order)
        {
            _logger.LogInformation($"SEARCH ID: {order.Id}");
            var foundOrder = await _orderService.GetOrderAsync(order);
            return Ok(foundOrder);
        }

        [Route("/api/orders/{id}/items/add")]
        [HttpPost]
        public async Task<IActionResult> AddItem(int id, [FromBody] AddOrderItemRequest orderItem)
        {
            _logger.LogInformation($"ADD ITEM TO ORDER: {id}");
            
            orderItem.OrderId = id;
            _logger.LogInformation($"ORDER ITEM: {orderItem.OrderId}, {orderItem.OrderItem}");
            var newOrderItem = await _orderService.AddOrderItem(orderItem);
            return Ok(newOrderItem);
        }
        
    }
}