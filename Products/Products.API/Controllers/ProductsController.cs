using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.BAL;
using Products.ViewModels;

namespace Products.API.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsBAL productsBAL;

        public ProductsController(IProductsBAL productsBAL)
        {
            this.productsBAL = productsBAL;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProducts()
        {
            var res = await productsBAL.GetProducts();
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> AddProduct(ProductViewModel obj)
        {
            var res = await productsBAL.Add(obj);
            return Ok(res);
        }
    }
}
