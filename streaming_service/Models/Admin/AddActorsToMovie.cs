using streaming_service.Entities;

namespace streaming_service.Models.Admin;

public class AddActorsToMovie
{
    public uint m_id { get; set; }

    public uint idOfSelectedActor { get; set; }
    public List<Actor>? Actors { get; set; }

}