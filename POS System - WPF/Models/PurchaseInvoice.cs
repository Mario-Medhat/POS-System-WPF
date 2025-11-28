using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public class PurchaseInvoice : Invoice
    {
        public int? SupplierId { get; private set; }
        public Supplier Supplier { get; private set; }

        public PurchaseInvoice(Supplier supplier = null)
        {
            Supplier = supplier;
            SupplierId = supplier?.SupplierId;
        }
    }
}
