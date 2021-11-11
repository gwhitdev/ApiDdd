using Microsoft.EntityFrameworkCore;
using Ddd.Core.Domain.Order;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Ddd.Core.Base;
using System.Linq;
using Ddd.Core.Domain.Audit;

namespace Ddd.Infrastructure.Database
{
    public class EfContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        private readonly IMediator _mediator; 
        public EfContext(DbContextOptions<EfContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            if (_mediator == null) return result;

            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach(var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach(var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }
            return result;
        }
        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
            modelBuilder.Entity<Audit>().ToTable("Audit");
        }
    }
}
