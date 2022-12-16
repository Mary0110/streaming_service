using streaming_service.Entities;

namespace streaming_service.Models.Admin;

public class AddGenresToMovie
{


    public uint m_id { get; set; }
    public List<Genre>? Genres{ get; set; }

    

    public uint idOfSelectedGenres { get; set; }
}