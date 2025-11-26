namespace POS.Domain.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }

        public string SupplierName { get; set; }
        
        public string ContactFullName { get; set; }

        public string Phone { get; set; }
        
        public string Email { get; set; }

        public List<Product> Products { get; set; }
    }
}
