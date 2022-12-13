using System;
using System.Collections.Generic;

namespace streaming_service
{
    public partial class Subscription
    {
        public Subscription()
        {
            Users = new HashSet<User>();
        }

        public uint SubscriptionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public uint PlanId { get; set; }
        public bool IsActive { get; set; }

        public virtual Plan Plan { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; }
    }
}
