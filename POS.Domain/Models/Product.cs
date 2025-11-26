namespace POS.Domain.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public ProductCategory Category { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }


        public int SupplierID { get; set; }

        public Supplier Supplier { get; set; }

        public List<SaleItem> Sales { get; set; }
        public List<InventoryLog> InventoryLogs { get; set; }
    }
}
