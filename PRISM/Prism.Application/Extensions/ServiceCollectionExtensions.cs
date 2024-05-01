using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Prism.Application.Categories;
using Prism.Application.Products;

namespace Prism.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            // Add Automap
            services.AddAutoMapper(applicationAssembly);

            // Add Fluent Validator
            services.AddValidatorsFromAssembly(applicationAssembly)
                .AddFluentValidationAutoValidation();
        }
    }
}