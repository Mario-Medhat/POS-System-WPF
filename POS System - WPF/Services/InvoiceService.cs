using POS_System___WPF.Data;
using POS_System___WPF.Interfaces;
using POS_System___WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace POS_System___WPF.Services
{

    public class InvoiceService : IInvoiceService
    {
        private readonly AppDbContext _db;

        public InvoiceService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Invoice> CreateInvoiceAsync()
        {
            var invoice = new Invoice();

            _db.Invoices.Add(invoice);
            await _db.SaveChangesAsync();

            return invoice;
        }

        public async Task AddnvoiceItemAsync(int invoiceId, int productId, int qty, decimal price)
        {
            var invoice = await _db.Invoices
                .Include(i => i.InvoiceItems)
                .FirstOrDefaultAsync(i => i.InvoiceId == invoiceId);

            var product = await _db.Products.FindAsync(productId);

            invoice.AddItem(product, qty, price);

            await _db.SaveChangesAsync();
        }

        public async Task PayAsync(int invoiceId, decimal amount)
        {
            var invoice = await _db.Invoices.FindAsync(invoiceId);

            invoice.AddPayment(amount);

            await _db.SaveChangesAsync();
        }

        public async Task CancelAsync(int invoiceId)
        {
            var invoice = await _db.Invoices.FindAsync(invoiceId);

            invoice.Cancel();

            await _db.SaveChangesAsync();
        }

        public async Task<Invoice> GetAsync(int invoiceId)
        {
            return await _db.Invoices
                .Include(i => i.InvoiceItems)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(i => i.InvoiceId == invoiceId);
        }
    }
}
