using Microsoft.EntityFrameworkCore;
using Products.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.DAL
{
    public class ProductsDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Types> Product_Types { get; set; }
        public ProductsDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {
            
        }
    }
}
