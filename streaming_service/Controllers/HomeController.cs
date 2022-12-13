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

 //    [HttpGet]
 //    public IActionResult AddOffer()
 //    {
 //        var model = new AddDirectorModel();
 //
 //        dbcommand.CommandText =
 //            @"SELECT apartments.id, apartmentstypes.apartments_type_name, apartments.count_rooms, apartments.count_floors, apartments.count_sleeping_places, apartmentsclasses.apartments_class_name FROM apartments
	// JOIN apartmentstypes ON apartments.apartments_type_id = apartmentstypes.id
	// 	JOIN apartmentsclasses ON apartments.apartments_class_id = apartmentsclasses.id";
 //
 //        var dataReader = dbcommand.ExecuteReader();
 //        // while (dataReader.Read())
 //        // {
 //        //     var tmp = new Director();
 //        //
 //        //     tmp.id = (Guid)dataReader.GetValue(0);
 //        //     tmp.AppTypeName = dataReader.GetValue(1) as string;
 //        //     tmp.CountRooms = (int)dataReader.GetValue(2);
 //        //     tmp.CountFloors = (int)dataReader.GetValue(3);
 //        //     tmp.CountSleepingPlaces = (int)dataReader.GetValue(4);
 //        //     tmp.AppClassName = dataReader.GetValue(5) as string;
 //        //
 //        //     model.Apartments.Add(tmp);
 //        // }
 //
 //        dataReader.Close();
 //
 //        return View(model);
 //    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}