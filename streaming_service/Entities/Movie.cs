using System;
using System.Collections.Generic;
using streaming_service.Entities;

namespace streaming_service
{
    public partial class Movie
    {
        public Movie()
        {
            Reviews = new HashSet<Review>();
            Actors = new HashSet<Actor>();
            Directors = new HashSet<Director>();
            Genres = new HashSet<Genre>();
            Sessions = new HashSet<Session>();
        }

        public uint MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public double? Rating { get; set; }
        public TimeOnly? Time { get; set; }
        public string? Description { get; set; }
        public bool? SubtitlesAvailable { get; set; }
        public short? Year { get; set; }
        public uint? AgeRestriction { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Director> Directors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
