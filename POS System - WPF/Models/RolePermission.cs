using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System___WPF.Models
{
    public class RolePermission
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Role> Roles { get; set; }
    }
}
