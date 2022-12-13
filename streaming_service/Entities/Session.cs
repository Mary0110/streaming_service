using System;
using System.Collections.Generic;

namespace streaming_service
{
    public partial class Session
    {
        public Session()
        {
            Movies = new HashSet<Movie>();
        }

        public uint SessionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public uint DeviceId { get; set; }
        public uint UserId { get; set; }

        public virtual Device Device { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
