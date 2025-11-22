using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public class InventoryLog
    {
        public int LogID { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int Change { get; set; } // +5, -3 ..etc

        public string ChangeType { get; set; } // SaleItem, Purchase, Manual

        public DateTime Date { get; set; }
    }
}
