using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ddd.Core.Interfaces;
using Ddd.Infrastructure.Repositories;
using Ddd.Core.Domain.Order;
using Ddd.Infrastructure.Database;
using Ddd.Services.Orders;
using System.Reflection;
using MediatR;
using Ddd.Events.Handlers.Orders;
using Ddd.Events.Handlers.Audits;
using Ddd.Services.Audits;

namespace Ddd.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>))
                .AddScoped<IOrderRepository, OrderRepository>();
        }
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));
            return services.AddDbContext<EfContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("MySql"), serverVersion,
                                     sqlOptions => sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().
                                                                                          Assembly.GetName().Name));
            }).AddDatabaseDeveloperPageExceptionFilter();

        }
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            return services.AddScoped<OrderService>().AddScoped<AuditService>();
        }
        public static IServiceCollection AddMediators(this IServiceCollection services)
        {
            return services.AddMediatR(typeof(OrderAddedEventHandler)).AddMediatR(typeof(AuditAddedEventHandler));
        }
    }
}
