using System;
using System.Collections.Generic;

namespace streaming_service
{
    public partial class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        public uint DirectorId { get; set; }
        public string DirectorName { get; set; } = null!;
        public string DirectorSurname { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
