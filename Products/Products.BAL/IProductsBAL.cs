using Products.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.BAL
{
    public interface IProductsBAL
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<ProductViewModel> Add(ProductViewModel productViewModel);
    }
}
