using POS_System___WPF.Data;
using POS_System___WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Interfaces
{
    public interface IInvoiceService
    {
        Task<Invoice> CreateInvoiceAsync();
        Task AddnvoiceItemAsync(int invoiceId, int productId, int qty, decimal price);
        Task PayAsync(int invoiceId, decimal amount);
        Task CancelAsync(int invoiceId);
        Task<Invoice> GetAsync(int invoiceId);
    }
}
