using System;
using Ddd.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ddd.DTOs.Orders;
using Ddd.Core.Domain.Order;
using System.Linq;
using Microsoft.Extensions.Logging;
namespace Ddd.Services.Orders
{
    public class OrderService : BaseService
    {
        private ILogger<OrderService> _logger;
        public OrderService(IUnitOfWork unitOfWork, ILogger<OrderService> logger) : base(unitOfWork)
        {
            _logger = logger;
        }

        public async Task<AddOrderResponse> AddNewAsync(AddOrderRequest model)
        {
            var order = new Order(
                    model.CustomerName,
                    model.OrderStatus);

            var repository = UnitOfWork.AsyncRepository<Order>();
            await repository.AddAsync(order);
            await UnitOfWork.SaveChangesAsync();

            var response = new AddOrderResponse()
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                OrderStatus = order.OrderStatus,
                CreatedDate = order.CreatedDate
            };

            return response;
        }

        public async Task<List<GetOrderResponse>> GetOrderAsync(GetOrderRequest request)
        {
            var respository = UnitOfWork.AsyncRepository<Order>();
            var order = await respository.GetAsync(_ => _.Id == request.Search);

            var orderDto = new GetOrderResponse()
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                CreatedDate = order.CreatedDate,
                OrderItems = order.OrderItems.ToList(),
                OrderStatus = order.OrderStatus
            };
            List<GetOrderResponse> response = new();
            response.Add(orderDto);
            
            return response;
        }
        
    }
}
