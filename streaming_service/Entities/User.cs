using System;
using System.Collections.Generic;

namespace streaming_service
{
    public partial class User
    {
        public User()
        {
            Loggers = new HashSet<Logger>();
            Payments = new HashSet<Payment>();
            ReviewAuthors = new HashSet<Review>();
            ReviewModerators = new HashSet<Review>();
        }

        public uint UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime JoinedDate { get; set; }
        public string Gender { get; set; } = null!;
        public uint Age { get; set; }
        public uint SubscriptionId { get; set; }
        public uint RoleId { get; set; }
        public double Balance { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual Subscription Subscription { get; set; } = null!;
        public virtual ICollection<Logger> Loggers { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Review> ReviewAuthors { get; set; }
        public virtual ICollection<Review> ReviewModerators { get; set; }
    }
}
