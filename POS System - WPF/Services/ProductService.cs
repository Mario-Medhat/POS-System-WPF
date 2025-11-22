using POS_System___WPF.Models;
using POS_System___WPF.Repositories.Interfaces;
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

        public Task<List<Product>> GetAllProducts() => _repo.GetAllAsync();

        public Task AddProduct(Product p) => _repo.AddAsync(p);

        public Task DeleteProduct(int id) => _repo.DeleteAsync(id);

        public Task UpdateProduct(Product p) => _repo.UpdateAsync(p);
    }

}
