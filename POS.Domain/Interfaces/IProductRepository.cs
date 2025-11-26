using POS.Domain.Models;

namespace POS.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetLowStockProducts(int threshold);
    }
}
