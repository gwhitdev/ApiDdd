using Microsoft.EntityFrameworkCore;
using Ddd.Core.Domain.Order;

namespace Ddd.Infrastructure.Database
{
    public class EfContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
        }
    }
}
