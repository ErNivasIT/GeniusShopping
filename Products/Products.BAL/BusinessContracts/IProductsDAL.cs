using Products.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.BAL
{
    public interface IProductsDAL
    {
        Task<ProductViewModel> Add(ProductViewModel productViewModel);
        Task<IEnumerable<ProductViewModel>> GetProducts();
    }
}
