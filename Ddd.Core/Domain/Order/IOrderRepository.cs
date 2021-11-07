using Ddd.Core.Interfaces;

namespace Ddd.Core.Domain.Order
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
