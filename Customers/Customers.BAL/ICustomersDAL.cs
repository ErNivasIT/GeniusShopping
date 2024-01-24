using Customers.ViewModels;

namespace Customers.BAL
{
    public interface ICustomersDAL
    {
        Task<CustomerViewModel> Add(CustomerViewModel productViewModel);
        Task<IEnumerable<CustomerViewModel>> GetCustomers();
    }
}
