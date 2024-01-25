using Customers.ViewModels;

namespace Customers.BAL.BusinessContracts
{
    public interface ICustomersBAL
    {
        Task<CustomerViewModel> Add(CustomerViewModel obj);
        Task<IEnumerable<CustomerViewModel>> Add(IEnumerable<CustomerViewModel> objList);
        Task<IEnumerable<CustomerViewModel>> GetCustomers();
    }
}
