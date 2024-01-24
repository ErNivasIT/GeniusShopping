using Microsoft.EntityFrameworkCore;
using Products.BAL;
using Products.DAL;

namespace Products.API.Dependencies
{
    public static class AppDependencies
    {
       
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductsBAL, ProductsBAL>();
            services.AddScoped<IProductsDAL, ProductsDAL>();
            return services;
        }
    }
}
