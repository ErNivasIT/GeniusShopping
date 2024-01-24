using Customers.BAL.BusinessContracts;
using Customers.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersBAL  customersBAL;

        public CustomersController(ICustomersBAL customersBAL)
        {
            this.customersBAL = customersBAL;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerViewModel>>> GetProducts()
        {
            var res = await customersBAL.GetCustomers();
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<CustomerViewModel>> AddProduct(CustomerViewModel obj)
        {
            var res = await customersBAL.Add(obj);
            return Ok(res);
        }
    }
}
