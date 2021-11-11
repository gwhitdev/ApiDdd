using System;
using System.Threading.Tasks;
using Ddd.Core.Base;
using Ddd.Core.Domain.Order;

namespace Ddd.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity;
        public Task<int> SaveChangesAsync();
        public IOrderRepository AsyncOrderRepository();
    }
}
