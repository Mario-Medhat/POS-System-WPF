using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }

        public int InvoiceId { get; set; } // Foreign Key
        public Invoice Invoice { get; set; }

        public int ProductId { get; set; } // Foreign Key
        public Product Product { get; set; }

        public decimal Quantity { get; set; }
        public decimal PriceAtSaleTime { get; set; }

        [NotMapped]
        public decimal TotalAmount => Quantity * PriceAtSaleTime;
        
        private InvoiceItem() { }

        public InvoiceItem(int invoiceId, int productId, decimal price, decimal qty)
        {
            InvoiceId = invoiceId;
            ProductId = productId;
            PriceAtSaleTime = price;
            Quantity = qty;
        }
    }
}
