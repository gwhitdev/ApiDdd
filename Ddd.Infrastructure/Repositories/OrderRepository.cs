using System;
using System.Threading.Tasks;
using Ddd.Core.Domain.Order;
using Ddd.Core.Interfaces;
using Ddd.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Ddd.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(EfContext dbContext) : base(dbContext)
        {

        }
        
    }
}
