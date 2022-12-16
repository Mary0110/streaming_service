using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using streaming_service.Entities;
using streaming_service.Models;

namespace streaming_service.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MySqlCommand dbcommand;


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        dbcommand = DB_Manager.getCommand();
    }

    [HttpGet]
    public IActionResult DirectorsIndex()
    {
        var model = new List<Director>();
 
        dbcommand.CommandText =
            @"SELECT * FROM directors";
 
        var dataReader = dbcommand.ExecuteReader();
        while (dataReader.Read())
        {
            var tmp = new Director();
        
            tmp.DirectorId = (uint)dataReader.GetValue(0);
            tmp.DirectorName = (string)dataReader.GetValue(1) as string;
            tmp.DirectorSurname = (string)dataReader.GetValue(2);
            tmp.DateOfBirth = (DateTime)dataReader.GetValue(3);
            tmp.Gender = (string)dataReader.GetValue(4);
        
            model.Add(tmp);
        }
        
        dataReader.Close();
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    public IActionResult MoviesIndex()
    {
        var movies = new List<Movie>();
 
        dbcommand.CommandText =
            @"SELECT m.movie_id,
               m.movie_name, 
               m.rating, 
               m.time, 
               m.description, 
               m.subtitles_available,
               m.year, 
               m.age_restriction FROM movies m ;";
         
        var dataReader = dbcommand.ExecuteReader();
        while (dataReader.Read())
        {
            var tmp = new Movie();
        
            tmp.MovieId = (uint)dataReader.GetValue(0);
            tmp.MovieName = (string)dataReader.GetValue(1);
            var rat = dataReader.GetValue(2);
            tmp.Rating = rat != DBNull.Value ? (double?)rat : null;
            var time = dataReader.GetValue(3);
            tmp.Time =  time != DBNull.Value ? (TimeSpan?)time : null;
            var descr = dataReader.GetValue(4);
            tmp.Description =  descr != DBNull.Value ? (string?)descr : null;
            var sub = dataReader.GetValue(5);

            tmp.SubtitlesAvailable =  sub != DBNull.Value ? (bool?)sub : null;
            var year = dataReader.GetValue(6);

            tmp.Year = year != DBNull.Value ? (int?)year : null;
            var age = dataReader.GetValue(7);

            tmp.AgeRestriction =age != DBNull.Value ? (uint?)age : null;
            movies.Add(tmp);
        }
        dataReader.Close();

        var model = new List<MovieModel>();
        foreach(var m in movies)
        {
            var mm = new MovieModel();

            mm.Movie = m;
            
            dbcommand.CommandText =
                @"SELECT d.director_id, d.director_name,
               d.director_surname, d.gender, d.date_of_birth 
               FROM movie_has_director mhd JOIN directors d ON mhd.director_id= d.director_id 
               WHERE mhd.movie_id =(@id2);";
            
            var id45 = dbcommand.CreateParameter();
            id45.ParameterName = "id2";
            id45.Value = m.MovieId;
            dbcommand.Parameters.Add(id45);
            
            var dataReader2 = dbcommand.ExecuteReader();
            var dirlist = new List<Director>();
            while (dataReader2.Read())
            {
                var tmp = new Director();
                tmp.DirectorId = (uint)dataReader2.GetValue(0);
                tmp.DirectorName = (string)dataReader2.GetValue(1);
                tmp.DirectorSurname = (string)dataReader2.GetValue(2);
                tmp.Gender = (string)dataReader2.GetValue(3);
                tmp.DateOfBirth = (DateTime)dataReader2.GetValue(4);
                    dirlist.Add(tmp);
            }
            dataReader2.Close();
            dbcommand.Parameters.Clear();
            mm.Directors = dirlist;
            model.Add(mm);
        }
        return View(model);    
    }
    
    [HttpGet]
    public IActionResult ActorsIndex()
    {
        var model = new List<Actor>();
 
        dbcommand.CommandText =
            @"SELECT * FROM actors;";
 
        var dataReader = dbcommand.ExecuteReader();
        while (dataReader.Read())
        {
            var tmp = new Actor();
        
            tmp.ActorId = (uint)dataReader.GetValue(0);
            tmp.ActorName = (string)dataReader.GetValue(1) as string;
            tmp.ActorSurname = (string)dataReader.GetValue(2);
            tmp.DateOfBirth = (DateTime)dataReader.GetValue(3);
            tmp.Gender = (string)dataReader.GetValue(4);
        
            model.Add(tmp);
        }
        
        dataReader.Close();
        return View(model);    }
}
