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
    public IActionResult Index()
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


    public IActionResult Films()
    {
        var model = new List<Movie>();
 
        dbcommand.CommandText =
            @"SELECT * FROM movies m JOIN directors";
 
        var dataReader = dbcommand.ExecuteReader();
        while (dataReader.Read())
        {
            var tmp = new Movie();
        
            tmp.DirectorId = (uint)dataReader.GetValue(0);
            tmp.DirectorName = (string)dataReader.GetValue(1) as string;
            tmp.DirectorSurname = (string)dataReader.GetValue(2);
            tmp.DateOfBirth = (DateTime)dataReader.GetValue(3);
            tmp.Gender = (string)dataReader.GetValue(4);
        
            model.Add(tmp);
        }
        
        dataReader.Close();
        return View(model);    }
}