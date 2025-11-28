using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    /// <summary>
    /// Represents a pricing tier for a specific product.
    /// Common use cases:
    /// - Retail price
    /// - Wholesale price
    /// - Bulk wholesale price
    /// Allows flexible pricing without bloating the Product entity.
    /// </summary>
    public class PriceLevel
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreign key linking to the related Product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Navigation property to the Product.
        /// </summary>
        public Product Product { get; set; } = null!;

        /// <summary>
        /// A readable name for the price tier.
        /// Examples: "Retail", "Wholesale", "Bulk".
        /// </summary>
        public string LevelName { get; set; } = null!;

        /// <summary>
        /// The actual price for this price level.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Timestamp for when this price level was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }


}
