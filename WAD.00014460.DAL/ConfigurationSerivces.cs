using System.Reflection;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WAD._00014460.Data;
using WAD._00014460.Interfaces;
using WAD._00014460.Repositories;
using Microsoft.Extensions.Configuration;

namespace WAD._00014460.DAL
{
    public static class ConfigurationSerivces
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITaskRepository, TaskItemRepository>();

            return services;
        }
    }
}
