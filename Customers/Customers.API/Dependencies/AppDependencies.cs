
using AspNetCoreRateLimit;
using Customers.BAL;
using Customers.BAL.BusinessContracts;
using Customers.DAL;
using Microsoft.Extensions.Configuration;
using Products.BAL;

namespace Products.API.Dependencies
{
    public static class AppDependencies
    {
       
        public static IServiceCollection AddDependencies(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<ICustomersBAL, CustomersBAL>();
            services.AddScoped<ICustomersDAL, CustomersDAL>();

            services.AddMemoryCache();
            services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));
            services.Configure<IpRateLimitPolicies>(configuration.GetSection("IpRateLimitPolicies"));
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            return services;
        }
    }
}
