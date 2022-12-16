using System;
using System.Collections.Generic;
using streaming_service.Entities;

namespace streaming_service.Entities
{
    public  class Movie
    {
        public uint MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public double? Rating { get; set; }
        public TimeSpan? Time { get; set; }
        public string? Description { get; set; }
        public bool? SubtitlesAvailable { get; set; }
        public int? Year { get; set; }
        public uint? AgeRestriction { get; set; }

    }
}
