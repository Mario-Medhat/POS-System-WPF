using Microsoft.EntityFrameworkCore;
using POS_System___WPF.Data;
using POS_System___WPF.Interfaces;
using POS_System___WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Repositories
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<ProductCategory>> GetAllProductCategories()
        {
            return _context.ProductCategories.ToListAsync();
        }
    }
}
