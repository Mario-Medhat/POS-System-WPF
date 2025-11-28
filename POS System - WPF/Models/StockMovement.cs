using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POS_System___WPF.Data.Enums;

namespace POS_System___WPF.Models
{
    public class StockMovement
    {
        public int Id { get; set; } 

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public decimal Quantity { get; set; }

        public MovementType MovementType { get; set; }

        public Invoice? Invoice { get; set; }

        public int? InvoiceId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? CreatedByUserId { get; set; }
        public User? CreatedByUser { get; set; }
    }

}
