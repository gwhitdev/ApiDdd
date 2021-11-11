using Ddd.Core.Interfaces;
using System.Threading.Tasks;

namespace Ddd.Core.Domain.Order
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        public Task<Order> GetOrderWithItemsAsync(int orderId);
    }
}
