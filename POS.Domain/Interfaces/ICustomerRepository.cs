using POS.Domain.Models;

namespace POS.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<List<Customer>> GetAllCustomers();
    }
}
