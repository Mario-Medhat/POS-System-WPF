using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POS_System___WPF.Data.Enums;

namespace POS_System___WPF.Models
{
    public class NotificationsLog
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;

        public NotificationsTypes Type { get; set; } = NotificationsTypes.Info; // Info, Warning, Error...

        public bool IsRead { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Optional: notification assigned to a user
        public int? LoggedOnUserId { get; set; }
        public User? LoggedOnUser { get; set; }
    }

}
