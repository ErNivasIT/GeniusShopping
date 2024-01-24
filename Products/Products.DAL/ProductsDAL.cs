using Microsoft.EntityFrameworkCore;
using Products.BAL;
using Products.Model;
using Products.ViewModels;

namespace Products.DAL
{
    public class ProductsDAL : IProductsDAL
    {
        private readonly ProductsDbContext productsDbContext;

        public ProductsDAL(ProductsDbContext productsDbContext)
        {
            this.productsDbContext = productsDbContext;
        }
        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var res = await productsDbContext.Products.ToListAsync();
            var response = res.Select(p => new ProductViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Added_By = p.Added_By,
                Added_By_IP = p.Added_By_IP,
                Added_On = p.Added_On,
                Description = p.Description,
                Is_Active = p.Is_Active,
                Price = p.Price,
            });
            return response;
        }
        public async Task<ProductViewModel> Add(ProductViewModel productViewModel)
        {
            var product = new Product()
            {
                Name = productViewModel.Name,
                Added_By = productViewModel.Added_By,
                Added_By_IP = productViewModel.Added_By_IP,
                Added_On = productViewModel.Added_On,
                Description = productViewModel.Description,
                Is_Active = productViewModel.Is_Active,
                Price = productViewModel.Price,
            };
            await productsDbContext.Products.AddAsync(product);
            await productsDbContext.SaveChangesAsync();
            productViewModel.Id = product.Id;

            return productViewModel;
        }
    }
}
