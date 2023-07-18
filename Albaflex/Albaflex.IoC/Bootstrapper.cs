using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Albaflex.Database;
using Albaflex.Data.Interfaces;
using Albaflex.Data.Repositories;
using Albaflex.Services.Services;
using Albaflex.Services.Validators;
using Albaflex.Services.Interfaces;
using Albaflex.CrossCutting.Notification;
using FluentMigrator.Runner;
using Albaflex.Data;

namespace Albaflex.IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<DbContext, AlbaflexDbContext>();
            services.AddScoped<NotificationContext>();

            services.AddScoped<ProductValidator>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductRepository, TissueRepository>();
            services.AddScoped<IProductService, ProductService>();
            
            return services;
        }

        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services)
        {
            services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddPostgres()
                .WithGlobalConnectionString(DbInfoProvider.GetPostgresConnectionString())
                .ScanIn(typeof(DbInfoProvider).Assembly).For.Migrations());

            return services;
        }
        
    }
}
