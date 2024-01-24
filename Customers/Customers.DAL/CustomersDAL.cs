using Customers.BAL;
using Customers.Models;
using Customers.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Customers.DAL
{
    public class CustomersDAL : ICustomersDAL
    {
        private readonly CustomersDbContext  customersDbContext;

        public CustomersDAL(CustomersDbContext customersDbContext)
        {
            this.customersDbContext = customersDbContext;
        }
        public async Task<IEnumerable<CustomerViewModel>> GetCustomers()
        {
            var res = await customersDbContext.Customers.ToListAsync();
            var response = res.Select(p => new CustomerViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email,
                Gender = p.Gender,
                MobileNo = p.MobileNo,
                Added_By = p.Added_By,
                Added_By_IP = p.Added_By_IP,
                Added_On = p.Added_On,
                Is_Active = p.Is_Active,
            });
            return response;
        }
        public async Task<CustomerViewModel> Add(CustomerViewModel customerViewModel)
        {
            var product = new Customer()
            {
                Name = customerViewModel.Name,
                Email = customerViewModel.Email,
                Gender = customerViewModel.Gender,
                MobileNo = customerViewModel.MobileNo,
                Added_By = customerViewModel.Added_By,
                Added_By_IP = customerViewModel.Added_By_IP,
                Added_On = customerViewModel.Added_On,
                Is_Active = customerViewModel.Is_Active,
            };
            await customersDbContext.Customers.AddAsync(product);
            await customersDbContext.SaveChangesAsync();
            customerViewModel.Id = product.Id;

            return customerViewModel;
        }
    }
}
