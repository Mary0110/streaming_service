using System;
using System.Collections.Generic;

namespace streaming_service
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public uint GenreId { get; set; }
        public string GenreName { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
