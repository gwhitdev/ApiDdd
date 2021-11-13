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
        private async Task AddToAudit(Order order)
        {
            order.AddToAudit();
            var repository = UnitOfWork.AsyncOrderRepository();
            await repository.UpdateAsync(order);
            await UnitOfWork.SaveChangesAsync();
            
        }
        public async Task<AddOrderResponse> AddNewAsync(AddOrderRequest model)
        {
            var order = new Order(
                    model.CustomerName,
                    model.OrderStatus,
                    model.OrderItems);

            var repository = UnitOfWork.AsyncRepository<Order>();
            await repository.AddAsync(order);
            await UnitOfWork.SaveChangesAsync();

            await AddToAudit(order);
            
            var response = new AddOrderResponse()
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                OrderStatus = order.OrderStatus,
                CreatedDate = order.CreatedDate,
                OrderItems = order.OrderItems.ToList()
            };

            return response;
        }

        public async Task<List<GetOrderResponse>> GetOrderAsync(GetOrderRequest request)
        {
            _logger.LogInformation($"{ request.Id}");
            var repository = UnitOfWork.AsyncOrderRepository();
            var order = await repository.GetOrderWithItemsAsync(request.Id);
            //repository.ListAsync(_ => _.GetOrderItems());
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

        public async Task<List<AddOrderItemResponse>> AddOrderItem(AddOrderItemRequest request)
        {
            _logger.LogInformation($"REQUEST SERVICE ORDER ID: {request.OrderId}");
            var repository = UnitOfWork.AsyncRepository<Order>();
            var order = await repository.GetAsync(_ => _.Id == request.OrderId);
            try
            {
                order.AddOrderItem(request.OrderItem.ItemName);

                await repository.UpdateAsync(order);
                await UnitOfWork.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            List<AddOrderItemResponse> response = new();
            response.Add(new AddOrderItemResponse()
            {
                Order = order
            });
            return response;
        }
    }
}
