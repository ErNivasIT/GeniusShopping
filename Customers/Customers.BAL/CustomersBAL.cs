
using Customers.BAL;
using Customers.BAL.BusinessContracts;
using Customers.ViewModels;

namespace Products.BAL
{
    public class CustomersBAL : ICustomersBAL
    {
        private readonly ICustomersDAL  customersDAL;

        public CustomersBAL(ICustomersDAL customersDAL)
        {
            this.customersDAL = customersDAL;
        }

        public async Task<CustomerViewModel> Add(CustomerViewModel obj)
        {
            var res = await customersDAL.Add(obj);
            return res;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetCustomers()
        {
            var res=await customersDAL.GetCustomers();
            return res;
        }
    }
}
