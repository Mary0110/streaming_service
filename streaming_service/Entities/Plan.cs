using System;
using System.Collections.Generic;

namespace streaming_service.Entities
{
    public partial class Plan
    {
        public Plan()
        {
            Subscriptions = new HashSet<Subscription>();
        }

        public uint PlanId { get; set; }
        public string PlanName { get; set; } = null!;
        public uint BaseRate { get; set; }
        public uint DurationMonths { get; set; }
        public string? PlanDescription { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
