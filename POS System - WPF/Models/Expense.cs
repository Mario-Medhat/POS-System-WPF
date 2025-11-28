using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public class Expense
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        // FK
        public int? CreatedByUserId { get; set; }

        // Navigation
        public User? CreatedByUser { get; set; }
    }

}
