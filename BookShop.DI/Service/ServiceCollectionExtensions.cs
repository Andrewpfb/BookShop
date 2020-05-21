using BookShop.Service.Interfaces;
using BookShop.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DI.Service
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBookShopServices(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
        }
    }
}
