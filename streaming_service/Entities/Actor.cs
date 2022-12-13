using System;
using System.Collections.Generic;

namespace streaming_service.Entities;

    public partial class Actor
    {
        public Actor()
        {
            Movies = new HashSet<Movie>();
        }

        public uint ActorId { get; set; }
        public string ActorName { get; set; } = null!;
        public string ActorSurname { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }

