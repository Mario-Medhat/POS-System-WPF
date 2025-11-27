using POS.Domain.Models;

namespace POS.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task<List<Product>> GetLowStockProducts(int threshold);
    }
}
