using streaming_service.Entities;

namespace streaming_service.Models;

public class MovieModel
{
    public Movie Movie { get; set; }
    public  List<Review> Reviews { get; set; }
    public  List<Actor> Actors { get; set; }
    public  List<Director> Directors { get; set; }
    public  List<Genre> Genres { get; set; }
}