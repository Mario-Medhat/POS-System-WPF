using POS.Domain.Models;

namespace POS.Domain.Interfaces
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        Task<List<ProductCategory>> GetAllProductCategories();
    }
}
