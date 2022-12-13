using System;
using System.Collections.Generic;

namespace streaming_service
{
    public partial class FilmsWithAuthors2
    {
        public uint MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public string? ActorNames { get; set; }
        public string? ActorSurnames { get; set; }
    }
}
