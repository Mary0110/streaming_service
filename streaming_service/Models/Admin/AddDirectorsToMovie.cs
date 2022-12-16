using streaming_service.Entities;

namespace streaming_service.Models.Admin;

public class AddDirectorsToMovie

{
    
    public uint m_id { get; set; }

    public List<Director>? Directors { get; set; }
    public uint idOfSelectedDirectors { get; set; } 

}