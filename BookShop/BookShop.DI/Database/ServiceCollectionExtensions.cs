using BookShop.Data.EF;
using BookShop.Data.Intefaces;
using BookShop.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.DI.Database
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BookShopContext>(options =>
            options.UseSqlServer(connectionString));
        }

        public static void AddDatabaseServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        }
    }
}
