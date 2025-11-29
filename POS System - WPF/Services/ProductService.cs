using POS_System___WPF.Interfaces;
using POS_System___WPF.Models;
using POS_System___WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public Task<IReadOnlyList<Product>> GetAllProducts() => _repo.ListAsync();

        public Task AddProduct(Product p) => _repo.AddAsync(p);

        public Task DeleteProduct(Product p) => _repo.DeleteAsync(p);

        public Task UpdateProduct(Product p) => _repo.UpdateAsync(p);

        public async Task SearchProducts(IProductRepository repo, string term)
        {
            var results = await repo.SearchAsync(
                q => q.Where(
                    p =>
                    p.ProductName.Contains(term) ||
                    p.Barcode.Contains(term) ||
                    p.Description.Contains(term)
                ),
                filter: p => p.IsActive,
                includes: p => p.Category // TODO: Test this include Code in the search method
            );

        }

    }

}
