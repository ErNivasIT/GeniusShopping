
using Customers.BAL;
using Customers.BAL.BusinessContracts;
using Customers.DAL;
using Products.BAL;

namespace Products.API.Dependencies
{
    public static class AppDependencies
    {
       
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomersBAL, CustomersBAL>();
            services.AddScoped<ICustomersDAL, CustomersDAL>();
            return services;
        }
    }
}
