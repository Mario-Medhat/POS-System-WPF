using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public enum ChangeType
    {
        SaleItem,
        Purchase,
        Manual,
    }

    public class InventoryLog
    {
        public int LogID { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public decimal StockChanged { get; set; } // +5, -3 ..etc

        public ChangeType ChangeType { get; set; }

        public DateTime LogDate { get; set; } = DateTime.Now;
        public string Note { get; private set; }

        private InventoryLog() { }
        public InventoryLog(Product product, decimal qty, ChangeType changeType, string note = "")
        {
            Product = product;
            ProductId = product.ProductId;
            StockChanged = qty;
            ChangeType = changeType;
            Note = note;
        }
    }
}
