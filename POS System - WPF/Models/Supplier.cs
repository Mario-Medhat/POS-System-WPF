using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }

        public string? ContactFullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public List<Product> Products { get; set; } = new();

        private Supplier() { }

        public Supplier(string supplierName, string contactFullName = null, string phone = null, string email = null)
        {
            SetSupplierName(supplierName);
            ContactFullName = contactFullName;
            Phone = phone;
            Email = email;
        }

        public void SetSupplierName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Supplier name cannot be empty");

            SupplierName = name.Trim();
        }
    }
}
