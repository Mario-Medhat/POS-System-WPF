using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POS_System___WPF.Data.Enums;

namespace POS_System___WPF.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; // e.g. "Admin", "Cashier"
        public string? Description { get; set; }

        // Useful flag for protecting system roles
        public bool IsSystem { get; set; } = false;

        // Navigation: many-to-many with User (assumes User entity exists)
        public List<User> Users { get; set; } = new();

        // Optional: many-to-many with Permission (if you implement permissions)
        public List<RolePermission>? RolePermissions { get; set; }
    }
}
