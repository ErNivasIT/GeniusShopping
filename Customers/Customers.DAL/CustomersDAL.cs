using Customers.BAL;
using Customers.Models;
using Customers.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace Customers.DAL
{
    public class CustomersDAL : ICustomersDAL
    {
        private readonly CustomersDbContext customersDbContext;
        private readonly IConfiguration configuration;

        public CustomersDAL(CustomersDbContext customersDbContext, IConfiguration configuration)
        {
            this.customersDbContext = customersDbContext;
            this.configuration = configuration;
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

        public async Task<IEnumerable<CustomerViewModel>> Add(IEnumerable<CustomerViewModel> objList)
        {
            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = configuration.GetConnectionString("CustomersConnection");

                foreach (var item in objList)
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                       
                        cmd.CommandText = "customers.`Add-Customers`";

                        cmd.Parameters.AddWithValue("Name", item.Name);
                        cmd.Parameters.AddWithValue("Gender", item.Gender);
                        cmd.Parameters.AddWithValue("Email", item.Email);
                        cmd.Parameters.AddWithValue("MobileNo", item.MobileNo);
                        cmd.Parameters.AddWithValue("Added_On", DateTime.Now);
                        cmd.Parameters.AddWithValue("Added_By", item.Added_By);
                        cmd.Parameters.AddWithValue("Added_By_IP", item.Added_By_IP);
                        cmd.Parameters.AddWithValue("Is_Active", item.Is_Active);

                        if (conn.State != System.Data.ConnectionState.Open)
                            await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        if (conn.State != System.Data.ConnectionState.Closed)
                            await conn.CloseAsync();
                    }
                }
                return objList;
            }
        }
    }
}
