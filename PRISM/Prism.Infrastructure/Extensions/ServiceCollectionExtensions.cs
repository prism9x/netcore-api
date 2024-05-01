using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prism.Domain.Repositories;
using Prism.Infrastructure.Persistence;
using Prism.Infrastructure.Repositories;
using Prism.Infrastructure.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PrismDb");
            services.AddDbContext<PrismDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IProductSeeders, ProductSeeders>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        }
    }
}