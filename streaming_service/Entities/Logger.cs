using System;
using System.Collections.Generic;

namespace streaming_service
{
    public partial class Logger
    {
        public uint LoggerId { get; set; }
        public string Action { get; set; } = null!;
        public string? ActionCategory { get; set; }
        public DateTime Time { get; set; }
        public uint UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
