using System;
using System.Collections.Generic;

namespace streaming_service.Entities
{
    public partial class Review
    {
        public uint ReviewId { get; set; }
        public string ReviewName { get; set; } = null!;
        public string ReviewText { get; set; } = null!;
        public uint AuthorId { get; set; }
        public uint MovieId { get; set; }
        public uint ModeratorId { get; set; }

        public virtual User Author { get; set; } = null!;
        public virtual User Moderator { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
