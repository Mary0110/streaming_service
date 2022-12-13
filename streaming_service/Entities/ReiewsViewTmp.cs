using System;
using System.Collections.Generic;

namespace streaming_service
{
    public partial class ReiewsViewTmp
    {
        public string ReviewName { get; set; } = null!;
        public string ReviewText { get; set; } = null!;
        public string? Author { get; set; }
        public uint ModeratorId { get; set; }
    }
}
