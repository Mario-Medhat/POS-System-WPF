using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // Cash / Card / Mixed / etc.
        public DateTime Date { get; set; }
    }
}
