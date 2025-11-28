using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public class ProductCategory
    {
        public int CategoryId { get; private set; }

        public string CategoryName { get; private set; }

        // Navigation
        public List<Product> Products { get; private set; } = new();

        public ProductCategory(string name)
        {
            SetName(name);
        }
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Category name cannot be empty");

            CategoryName = name.Trim();
        }

        public void AddProduct(Product product)
        {
            if (product == null) return;

            product.AssignCategory(this);
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            if (product == null) return;

            product.ClearCategory();
            Products.Remove(product);
        }
    }
}
