using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ddd.Core.Domain.Order;
using Ddd.Core.Interfaces;
using Ddd.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ddd.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly EfContext _context;
        public OrderRepository(EfContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<Order> GetOrderWithItemsAsync(int orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            await _context.Entry(order).Collection(i => i.OrderItems).LoadAsync();
            return order;
            
        }


        

    }
}
