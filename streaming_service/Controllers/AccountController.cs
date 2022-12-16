using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using streaming_service.Entities;
using streaming_service.Models;

namespace streaming_service.Controllers;

public class AccountController : Controller
{
    private readonly MySqlCommand dbcommand;

    // GET

    public AccountController()
    {
        dbcommand = DB_Manager.getCommand();
    }



   async  public Task<IActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
            if (CheckForSignUp(model.Login))
            {
                await SignUpUser(model);
                return RedirectToAction("Profile", "Client");
            }

        return View(model);
    
    }

    private bool CheckForSignUp(string email)
    {
        dbcommand.CommandText = @"SELECT * FROM users WHERE email = (@p1)";

        var params1 = dbcommand.CreateParameter();

        params1.ParameterName = "p1";
        params1.Value = email;

        dbcommand.Parameters.Add(params1);

        var dataReader = dbcommand.ExecuteReader();

        if (dataReader.Read() == false)
        {
            dataReader.Close();
            dbcommand.Parameters.Clear();
            return true;
        }
        dataReader.Close();
        return false;
    }

[HttpGet]
    public IActionResult Register()
    {
        return View();
    }

   

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var role = "";
        if (ModelState.IsValid)
        {
            if (CheckForSignIn(model.Login, model.Password, out role))
            {
                await SignInUser(model.Login);
                if (role == "client")
                {
                    return RedirectToAction("Profile", "Client");
                }
                else if (role == "admin")
                {
                    return RedirectToAction("Profile", "Admin");
                }
                else if (role == "moderator")
                {
                    return RedirectToAction("Profile", "Moderator");
                }
            }
        }

        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignOutAsync();
        HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
        return RedirectToAction("MoviesIndex", "Home");
    }

    public string CheckRole(string login)
    {
        var role = "";

        dbcommand.CommandText = @"SELECT * FROM users
	JOIN roles ON users.role_id = roles.role_id AND email = (@p1);";

        var params1 = dbcommand.CreateParameter();

        params1.ParameterName = "p1";
        params1.Value = login;

        dbcommand.Parameters.Add(params1);

        var dataReader = dbcommand.ExecuteReader();

        if (dataReader.Read() == false)
        {
            role = "";
            dataReader.Close();

            dbcommand.Parameters.Clear();
            return role;
        }

        role = dataReader.GetValue(dataReader.GetOrdinal("role_name")).ToString();
        dbcommand.Parameters.Clear();
        dataReader.Close();

        return role;
    }



private async Task SignUpUser(RegisterModel model)
{
    dbcommand.CommandText = @"CALL register_form((@p1), (@p2), (@p3), (@p4), (@p5));";
    var params1 = dbcommand.CreateParameter();
    var params2 = dbcommand.CreateParameter();
    var params3 = dbcommand.CreateParameter();
    var params4 = dbcommand.CreateParameter();
    var params5 = dbcommand.CreateParameter();


    params1.ParameterName = "p1";
    params1.Value = model.Username;

    params2.ParameterName = "p2";
    params2.Value = model.Login;

    params3.ParameterName = "p3";
    params3.Value = model.Password;

    params4.ParameterName = "p4";
    params4.Value = model.Gender;

    params5.ParameterName = "p5";
    string formatForMySql = model.DateOfBirth.ToString("yyyy-MM-dd HH:mm");

    params5.Value = formatForMySql;

    dbcommand.Parameters.Add(params1);
    dbcommand.Parameters.Add(params2);
    dbcommand.Parameters.Add(params3);
    dbcommand.Parameters.Add(params4);
    dbcommand.Parameters.Add(params5);

    dbcommand.ExecuteReader();
    dbcommand.Parameters.Clear();

    await SignInUser(model.Login);
}

private async Task SignInUser(string email)
{
    var claims = new List<Claim>
    {
        new(ClaimTypes.Name, email)
    };

    var claimsIdentity = new ClaimsIdentity(
        claims, CookieAuthenticationDefaults.AuthenticationScheme);

    await HttpContext.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        new ClaimsPrincipal(claimsIdentity));
}
private bool CheckForSignIn(string email, string password, out string? role)
{
    dbcommand.CommandText = @"SELECT * FROM users
	JOIN roles ON users.role_id = roles.role_id AND email = (@p1) AND password = (@p2);";

    var params1 = dbcommand.CreateParameter();
    var params2 = dbcommand.CreateParameter();

    params1.ParameterName = "p1";
    params1.Value = email;

    params2.ParameterName = "p2";
    params2.Value = password;

    dbcommand.Parameters.Add(params1);
    dbcommand.Parameters.Add(params2);

    var dataReader = dbcommand.ExecuteReader();

    if (dataReader.Read() == false)
    {
        role = "";
        dbcommand.Parameters.Clear();
        dataReader.Close();

        return false;
    }
    dataReader.Close();

    role = dataReader.GetValue(dataReader.GetOrdinal("role_name")).ToString();
    dbcommand.Parameters.Clear();
    dataReader.Close();

    return true;
}

}