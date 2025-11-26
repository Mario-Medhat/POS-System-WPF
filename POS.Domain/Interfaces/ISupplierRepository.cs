using POS.Domain.Models;

namespace POS.Domain.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<List<Supplier>> GetAllSuppliers(int threshold);
    }
}
