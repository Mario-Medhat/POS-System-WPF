using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public class SaleInvoice : Invoice
    {
        public int? CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        public SaleInvoice(Customer customer = null)
        {
            Customer = customer;
            CustomerId = customer?.CustomerId;
        }
    }
}
