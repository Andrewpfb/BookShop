using AutoMapper;
using BookShop.Core.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookShop.DI.Common
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMapper(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddAutoMapper(c=>c.AddProfile<AutoMapperProfile>(),assemblies);
        }
    }
}
