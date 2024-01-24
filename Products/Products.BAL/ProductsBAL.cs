
using Products.ViewModels;

namespace Products.BAL
{
    public class ProductsBAL : IProductsBAL
    {
        private readonly IProductsDAL productsDAL;

        public ProductsBAL(IProductsDAL productsDAL)
        {
            this.productsDAL = productsDAL;
        }

        public async Task<ProductViewModel> Add(ProductViewModel productViewModel)
        {
            var res = await productsDAL.Add(productViewModel);
            return res;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var res=await productsDAL.GetProducts();
            return res;
        }
    }
}
