using POS_System___WPF.Data;
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
        public int ProductId { get; private set; }

        public string ProductName { get; private set; }
        public string Barcode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; private set; }
        // ✅ Using decimal for stock to support fractional quantities
        public decimal Stock { get; private set; }
        // ✅ Soft delete / Enable disable
        public bool IsActive { get; set; } = true;

        public int CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }

        public int SupplierId { get; private set; }

        public Supplier Supplier { get; private set; }

        public List<InvoiceItem> InvoiceItems { get; private set; }
        public List<InventoryLog> InventoryLogs { get; private set; }
        public List<PriceLevel> PriceLevels { get; set; } = new();
        public List<StockMovement> StockMovements { get; set; } = new();
        private Product() { }

        public Product(string name, decimal price, decimal stock = 0)
        {
            SetName(name);
            SetPrice(price);
            SetStock(stock);
        }

        private void SetStock(decimal stock)
        {
            if (stock < 0)
                throw new ArgumentException("Stock quantity cannot be negative");

            Stock = stock;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty");

            ProductName = name;
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentException("Price should be greater than zero");

            Price = price;
        }

        public void IncreaseStock(decimal qty)
        {
            if (qty <= 0)
            {
                throw new ArgumentException("Quantity should be greater than zero");
            }
            Stock += qty;

            InventoryLogs.Add(new InventoryLog(product: this, qty: qty, changeType: Enums.StockChangeType.Purchase));
        }

        public void DecreaseStock(decimal qty)
        {
            if (qty <= 0) return;
            if (Stock < qty)
                throw new InvalidOperationException("Not enough stock");

            Stock -= qty;
            InventoryLogs.Add(new InventoryLog(product: this, qty: -qty, Enums.StockChangeType.SaleItem));
        }

        internal void AssignCategory(ProductCategory category)
        {
            Category = category;
            CategoryId = category.CategoryId;
        }

        internal void ClearCategory()
        {
            Category = null;
            CategoryId = 0;
        }
    }

}
