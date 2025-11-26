using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Models
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
