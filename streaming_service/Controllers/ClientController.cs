using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using streaming_service.Entities;
using streaming_service.Models;

namespace streaming_service.Controllers;

public class ClientController : Controller
{
    private readonly MySqlCommand dbcommand;

    public ClientController()
    {
        dbcommand = DB_Manager.getCommand();
    }


    [HttpGet]
    public IActionResult Profile()
    {
        return View(GetClient());
    }
    public IActionResult CreateReview()
    {
        throw new NotImplementedException();
    }

    public ClientProfileModel GetClient()
    {
        var model = new ClientProfileModel();

        dbcommand.CommandText =
            @"SELECT users.user_id, users.email, users.password, users.username, users.age FROM users
	where users.email = (@p1);";

        var params1 = dbcommand.CreateParameter();

        params1.ParameterName = "p1";
        params1.Value = User.Identity.Name;

        dbcommand.Parameters.Add(params1);

        var dataReader = dbcommand.ExecuteReader();

        while (dataReader.Read())
        {
            model.id = (uint?)dataReader.GetValue(dataReader.GetOrdinal("user_id"));
            model.Login = dataReader.GetValue(dataReader.GetOrdinal("email")).ToString();
            model.Password = dataReader.GetValue(dataReader.GetOrdinal("password")).ToString();
            model.Username = dataReader.GetValue(dataReader.GetOrdinal("username")).ToString();
            model.DateOfBirth =
                DateOnly.FromDateTime((DateTime)dataReader.GetValue(dataReader.GetOrdinal("age")));
        }

        dataReader.Close();
        dbcommand.Parameters.Clear();

        return model;
    }
}