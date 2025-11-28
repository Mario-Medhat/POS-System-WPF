using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public enum PaymentMethod
    {
        Cash,
        Card,
        Mixed,
    }

    public class Payment
    {
        public int PaymentId { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime PaidAt { get; set; } = DateTime.Now;

        private Payment() { }
        public Payment(Invoice invoice, decimal amount, PaymentMethod paymentMethod = PaymentMethod.Cash)
        {
            Invoice = invoice;
            InvoiceId = invoice.InvoiceId;
            Amount = amount;
            PaymentMethod = paymentMethod;
        }

    }
}
