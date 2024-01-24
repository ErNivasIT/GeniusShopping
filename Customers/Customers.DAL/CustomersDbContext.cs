using Customers.Models;
using Microsoft.EntityFrameworkCore;

namespace Customers.DAL
{
    public class CustomersDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CustomersDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {
            
        }
    }
}
