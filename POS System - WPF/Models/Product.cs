using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }


        public int SupplierID { get; set; }

        public Supplier Supplier { get; set; }

        public List<SaleItem> Sales { get; set; }
        public List<InventoryLog> InventoryLogs { get; set; }
    }
}
