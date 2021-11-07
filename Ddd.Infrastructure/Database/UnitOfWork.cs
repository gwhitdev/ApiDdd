using System;
using System.Threading.Tasks;
using Ddd.Core.Base;
using Ddd.Core.Interfaces;
using Ddd.Infrastructure.Repositories;

namespace Ddd.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfContext _dbContext;

        public UnitOfWork(EfContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity
        {
            return new RepositoryBase<T>(_dbContext);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
