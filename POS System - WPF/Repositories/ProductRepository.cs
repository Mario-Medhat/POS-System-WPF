using Microsoft.EntityFrameworkCore;
using POS_System___WPF.Data;
using POS_System___WPF.Models;
using POS_System___WPF.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetLowStockProducts(int threshold)
        {
            return await _context.Products
                .Where(p => p.Quantity <= threshold)
                .ToListAsync();
        }
    }
}
