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
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Supplier>> GetAllSuppliers(int threshold)
        {
            try
            {
                return await _context.Suppliers.ToListAsync();

            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"An error occurred while retrieving suppliers: {ex.Message}");
                throw; // Re-throw the exception after logging it
            }
        }
    }
}
