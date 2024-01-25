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
        public async Task<ActionResult<IEnumerable<CustomerViewModel>>> GetCustomers()
        {
            var res = await customersBAL.GetCustomers();
            Console.WriteLine("Called at "+DateTime.Now);
            return Ok(res);
        }
        [HttpPost]
        public async Task<ActionResult<CustomerViewModel>> AddCustomer(CustomerViewModel obj)
        {
            var res = await customersBAL.Add(obj);
            return Ok(res);
        }
        [HttpPost]
        [Route("AddBulk")]
        public async Task<ActionResult<IEnumerable<CustomerViewModel>>> AddBulkCustomer(IEnumerable<CustomerViewModel> objList)
        {
            var res = await customersBAL.Add(objList);
            return Ok(res);
        }
    }
}
