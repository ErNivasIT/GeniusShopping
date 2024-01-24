using Customers.ViewModels;

namespace Customers.BAL.BusinessContracts
{
    public interface ICustomersBAL
    {
        Task<CustomerViewModel> Add(CustomerViewModel obj);
        Task<IEnumerable<CustomerViewModel>> GetCustomers();
    }
}
