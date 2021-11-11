using System;
using System.Threading.Tasks;
using Ddd.Core.Base;
using Ddd.Core.Interfaces;
using Ddd.Infrastructure.Repositories;
using Ddd.Core.Domain.Order;
using Microsoft.Extensions.Logging;

namespace Ddd.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfContext _dbContext;
        private ILogger<UnitOfWork> _logger;
        private int ManyTimes = 0;
        public UnitOfWork(EfContext dbContext, ILogger<UnitOfWork> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            
        }

        public IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity
        {
            return new RepositoryBase<T>(_dbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            ManyTimes++;
            _logger.LogInformation($"{ManyTimes} {_dbContext}");
            return await _dbContext.SaveChangesAsync();
        }

        public IOrderRepository AsyncOrderRepository()
        {
            return new OrderRepository(_dbContext);
        }
    }
}
