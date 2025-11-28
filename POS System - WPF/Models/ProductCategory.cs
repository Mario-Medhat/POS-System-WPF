using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }
        public List<Product> Products { get; private set; } = new();

    }
}
