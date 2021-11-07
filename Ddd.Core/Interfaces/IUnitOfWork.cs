using System;
using System.Threading.Tasks;
using Ddd.Core.Base;

namespace Ddd.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity;
        public Task<int> SaveChangesAsync();
    }
}
