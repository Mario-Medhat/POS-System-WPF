using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public class SaleItem
    {
        public int SaleItemID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public int Quantity { get; set; }
        public decimal PriceAtSaleTime { get; set; }
        public DateTime Date { get; set; }

        [NotMapped]
        public decimal TotalAmount => Quantity * PriceAtSaleTime;


        public string PaymentStatus { get; set; }

        public List<Payment> Payments { get; set; }
    }
}
