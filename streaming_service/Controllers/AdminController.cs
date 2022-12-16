
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySqlConnector;
using streaming_service.Entities;
using streaming_service.Models;
using streaming_service.Models.Admin;

namespace streaming_service.Controllers;

public class AdminController : Controller
{
	// GET
	private readonly MySqlCommand dbcommand;

	public AdminController()
	{
		dbcommand = DB_Manager.getCommand();
	}

	[HttpGet]
	public IActionResult Logs()
	{
		var model = new LogModel();
		model.logs = new List<Logger>();
		dbcommand.CommandText =
			@"SELECT logger.logger_id, logger.action , logger.action_category,logger.time, users.user_id FROM logger
                JOIN users ON logger.user_id = users.user_id;";

		using (var dataReader15 = dbcommand.ExecuteReader())
		{
			while (dataReader15.Read())
			{
				var tmp = new Logger();
				tmp.LoggerId = (uint)dataReader15.GetValue(0);
				tmp.Action = (string)dataReader15.GetValue(1);
				tmp.ActionCategory = (string)dataReader15.GetValue(2);
				tmp.Time = (DateTime)dataReader15.GetValue(3);
				tmp.UserId = (uint)dataReader15.GetValue(4);
				model.logs.Add(tmp);
			}
		}

		//dataReader15.Close();

		return View(model);
	}

	private AdminProfileModel GetAdmin()
	{
		var model = new AdminProfileModel();

		dbcommand.CommandText =
			@"SELECT users.user_id, users.email FROM users where users.email = (@p1) AND users.role_id = 2;";

		var params1 = dbcommand.CreateParameter();

		params1.ParameterName = "p1";
		params1.Value = User.Identity.Name;

		dbcommand.Parameters.Add(params1);

		var dataReader13 = dbcommand.ExecuteReader();

		while (dataReader13.Read())
		{
			model.id = (uint?)dataReader13.GetValue(dataReader13.GetOrdinal("user_id"));
			model.Login = dataReader13.GetValue(dataReader13.GetOrdinal("email")).ToString();
		}
		dataReader13.Close();
		dbcommand.Parameters.Clear();

		

		return model;
	}

	[HttpGet]
	public IActionResult Profile()
	{
		return View(GetAdmin());
	}

	public IActionResult Clients()
	{
		var model = new ClientsModel();
		model.Clients = new List<User>();

		dbcommand.CommandText =
			@"select user_id, username, age, gender, joined_date, balance, email  from users where role_id = (select role_id from roles where role_name = 'user');";
		using (var dataReader12 = dbcommand.ExecuteReader())
		{
			while (dataReader12.Read())
			{
				var tmp = new User();
				tmp.UserId = (uint)dataReader12.GetValue(0);
				tmp.Username = dataReader12.GetValue(1) as string;
				tmp.Age = (DateTime)dataReader12.GetValue(2);
				tmp.Gender = (string)dataReader12.GetValue(3);
				tmp.JoinedDate = (DateTime)dataReader12.GetValue(4);
				tmp.Balance = (double)dataReader12.GetValue(5);
				tmp.Email = (string)dataReader12.GetValue(6);

				model.Clients.Add(tmp);
			}
		}

		//dataReader12.Close();
		return View(model);
	}
	

	[HttpGet]
	public IActionResult AddDirector()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> AddDirector(AddDirectorModel model)
	{
		if (ModelState.IsValid)
		{
			dbcommand.CommandText = @"INSERT INTO directors(director_name, director_surname, date_of_birth, gender) VALUES (
			   (@p1),
			   (@p2),
			   (@p3),
			   (@p4)
			   );";

			var params1 = dbcommand.CreateParameter();
			var params2 = dbcommand.CreateParameter();
			var params3 = dbcommand.CreateParameter();
			var params4 = dbcommand.CreateParameter();

			params1.ParameterName = "p1";
			params1.Value = model.Name;

			params2.ParameterName = "p2";
			params2.Value = model.Surname;

			params3.ParameterName = "p3";
			params3.Value = model.DateOfBirth;

			params4.ParameterName = "p4";
			params4.Value = model.Gender;
			

			dbcommand.Parameters.Add(params1);
			dbcommand.Parameters.Add(params2);
			dbcommand.Parameters.Add(params3);
			dbcommand.Parameters.Add(params4);

			dbcommand.ExecuteReader();
			dbcommand.Parameters.Clear();
			

			return RedirectToAction("Profile", "Admin");
		}

		return View(model);
	}

	[HttpGet]
	public IActionResult AddActor()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> AddActor(AddActorModel model)
	{
		if (ModelState.IsValid)
		{
			dbcommand.CommandText = @"INSERT INTO actors(actor_name, actor_surname, date_of_birth, gender) VALUES (
				   (@p1),
				   (@p2),
				   (@p3),
				   (@p4)
				   );";

			var params1 = dbcommand.CreateParameter();
			var params2 = dbcommand.CreateParameter();
			var params3 = dbcommand.CreateParameter();
			var params4 = dbcommand.CreateParameter();

			params1.ParameterName = "p1";
			params1.Value = model.Name;

			params2.ParameterName = "p2";
			params2.Value = model.Surname;

			params3.ParameterName = "p3";
			params3.Value = model.DateOfBirth;

			params4.ParameterName = "p4";
			params4.Value = model.Gender;
				

			dbcommand.Parameters.Add(params1);
			dbcommand.Parameters.Add(params2);
			dbcommand.Parameters.Add(params3);
			dbcommand.Parameters.Add(params4);

			dbcommand.ExecuteReader();
			dbcommand.Parameters.Clear();

			return RedirectToAction("Profile", "Admin");
		}

		return View(model);
	}

	[HttpGet]
    public IActionResult AddMovie()
    {
	    var model = new AddMovieModel();
	    return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddMovie(AddMovieModel model)
    {
	    if (ModelState.IsValid)
	    {

		    dbcommand.CommandText = @"INSERT INTO movies(
movie_name, time,
description, subtitles_available,
year,
age_restriction) VALUES (
						   (@p1),
						   (@p2),
						   (@p3),
						   (@p4),
						  (@p5) ,
						   (@p6));";

		    var params1 = dbcommand.CreateParameter();
		    var params2 = dbcommand.CreateParameter();
		    var params3 = dbcommand.CreateParameter();
		    var params4 = dbcommand.CreateParameter();
		    var params5 = dbcommand.CreateParameter();
		    var params6 = dbcommand.CreateParameter();

		    params1.ParameterName = "p1";
		    params1.Value = model.MovieName.ToString();

		    params2.ParameterName = "p2";
		    params2.Value = model.Time;

		    params3.ParameterName = "p3";
		    params3.Value = model.Description;

		    params4.ParameterName = "p4";
		    params4.Value = model.SubtitlesAvailable;

		    params5.ParameterName = "p5";

		    params5.Value = model.Year;

		    params6.ParameterName = "p6";
		    params6.Value = model.AgeRestriction.ToString();

		    dbcommand.Parameters.Add(params1);
		    dbcommand.Parameters.Add(params2);
		    dbcommand.Parameters.Add(params3);
		    dbcommand.Parameters.Add(params4);
		    dbcommand.Parameters.Add(params5);
		    dbcommand.Parameters.Add(params6);
		    dbcommand.ExecuteReader();
		    dbcommand.Parameters.Clear();
		    
		    // dbcommand.CommandText=@"select max(movie_id) from movies limit 1;";
		    uint _movie_id = 0;
		    _movie_id = (uint)dbcommand.LastInsertedId;
		    Console.WriteLine("movie111111111111111111,.");

		    Console.WriteLine(_movie_id);
		    return RedirectToAction("AddDirectorsToMovie", new { movie_id = _movie_id });
	    }
	    return View(model);
    }
    
    [HttpGet]

      public IActionResult AddDirectorsToMovie(uint id)
    {
        var model = new AddDirectorsToMovie();
        model.Directors = new List<Director?>();
        model.m_id = id;
        // model.m_id=

        dbcommand.CommandText =
	        @"SELECT * from directors;";

        var dataReader10 = dbcommand.ExecuteReader();
        
        while (dataReader10.Read())
        {
	        var tmp = new Director();

	        tmp.DirectorId = (uint)dataReader10.GetValue(0);
	        tmp.DirectorName = dataReader10.GetValue(1) as string;
	        tmp.DirectorSurname = (string)dataReader10.GetValue(2);
	        tmp.Gender = (string)dataReader10.GetValue(4);
	        tmp.DateOfBirth = (DateTime)dataReader10.GetValue(3);
	        model.Directors.Add(tmp);
        }
        

        dataReader10.Close();

        return View(model);
    }

    [HttpPost]
    [Route("Admin/AddDirectorsToMovie/{movie_id:int}")]
    public async Task<IActionResult> AddDirectorsToMovie(AddDirectorsToMovie model, uint movie_id)
    {

	    var justValue = this.ControllerContext.RouteData.Values["movie_id"].ToString();
	    uint val = Convert.ToUInt32(justValue, 16);

	    model.m_id = movie_id;
        if (ModelState.IsValid)
        {
            dbcommand.CommandText = @"INSERT INTO movie_has_director(movie_id,director_id) VALUES (
						   (@p1),
						   (@p2)
						   );";
            Console.WriteLine("00000000000000000");

            Console.WriteLine(movie_id);
            Console.WriteLine(model.idOfSelectedDirectors);

        
            var params1 = dbcommand.CreateParameter();
            var params2 = dbcommand.CreateParameter();
           
            params1.ParameterName = "p1";
            params1.Value = model.m_id;

            params2.ParameterName = "p2";
            params2.Value = model.idOfSelectedDirectors;

            
            dbcommand.Parameters.Add(params1);
            dbcommand.Parameters.Add(params2);
           

            dbcommand.ExecuteReader();
            dbcommand.Parameters.Clear();

            return RedirectToAction("AddDirectorsToMovie", new { movie_id = model.m_id  });
        }

        return View(model);
    }

    
    [HttpGet]
    public IActionResult AddActorsToMovie(uint id)
    {
	    var model = new AddActorsToMovie();
	    model.Actors = new List<Actor?>();
	    model.m_id = id;

	    dbcommand.CommandText =
		    @"SELECT * from actors;";

	    var dataReader10 = dbcommand.ExecuteReader();
        
	    while (dataReader10.Read())
	    {
		    var tmp = new Actor();

		    tmp.ActorId = (uint)dataReader10.GetValue(0);
		    tmp.ActorName = dataReader10.GetValue(1) as string;
		    tmp.ActorSurname = (string)dataReader10.GetValue(2);
		    tmp.Gender = (string)dataReader10.GetValue(4);
		    tmp.DateOfBirth = (DateTime)dataReader10.GetValue(3);
		    model.Actors.Add(tmp);
	    }
        

	    dataReader10.Close();

	    return View(model);
    }

    [HttpPost]
    [Route("Admin/AddActorsToMovie/{movie_id:int}")]

    public async Task<IActionResult> AddActorsToMovie(AddActorsToMovie model, uint movie_id)

    {
	    var justValue = this.ControllerContext.RouteData.Values["movie_id"].ToString();
	    uint val = Convert.ToUInt32(justValue, 16);
	    model.m_id = movie_id;
	    
	    if (ModelState.IsValid)
	    {
		    dbcommand.CommandText = @"INSERT INTO movie_has_actor(movie_id,actor_id) VALUES (
						   (@p1),
						   (@p2)
						   );";

		    var params1 = dbcommand.CreateParameter();
		    var params2 = dbcommand.CreateParameter();
           
		    params1.ParameterName = "p1";
		    params1.Value = model.m_id;

		    params2.ParameterName = "p2";
		    params2.Value = model.idOfSelectedActor;

            
		    dbcommand.Parameters.Add(params1);
		    dbcommand.Parameters.Add(params2);
           

		    dbcommand.ExecuteReader();
		    dbcommand.Parameters.Clear();

		    return RedirectToAction("AddActorsToMovie", new { movie_id = model.m_id });
	    }

	    return View(model);
    }
    [HttpGet]
    public IActionResult AddGenresToMovie(uint id )
    {
	    var model = new AddGenresToMovie();
	    model.Genres = new List<Genre?>();
	    model.m_id = id;
	    dbcommand.CommandText =
		    @"SELECT * from genres;";

	    var dataReader10 = dbcommand.ExecuteReader();
        
	    while (dataReader10.Read())
	    {
		    var tmp = new Genre();

		    tmp.GenreId = (uint)dataReader10.GetValue(0);
		    tmp.GenreName = dataReader10.GetValue(1) as string;
		    
		    model.Genres.Add(tmp);
	    }
        

	    dataReader10.Close();

	    return View(model);
    }

    [HttpPost]
    [Route("Admin/AddGenresToMovie/{movie_id:int}")]

    public async Task<IActionResult> AddGenresToMovie(AddGenresToMovie model, uint movie_id)

    {
	   
	    model.m_id = movie_id;
	    if (ModelState.IsValid)
	    {
		    dbcommand.CommandText = @"select *from movie_has_genre where movie_id = @p1 and genre_id = @p2 limit 1;";

		    var pparams1 = dbcommand.CreateParameter();
		    var pparams2 = dbcommand.CreateParameter();
           
		    pparams1.ParameterName = "p1";
		    pparams1.Value = model.m_id;

		    pparams2.ParameterName = "p2";
		    pparams2.Value = model.idOfSelectedGenres;

            
		    dbcommand.Parameters.Add(pparams1);
		    dbcommand.Parameters.Add(pparams2);
           

		    var a = dbcommand.ExecuteScalar();
		    dbcommand.Parameters.Clear();
		    
		    if(a != null)
			    return RedirectToAction("AddGenresToMovie", new { movie_id = model.m_id });
		    
		    dbcommand.CommandText = @"INSERT INTO movie_has_genre(movie_id,genre_id) VALUES (
						   (@p1),
						   (@p2)
						   );";

		    var params1 = dbcommand.CreateParameter();
		    var params2 = dbcommand.CreateParameter();
           
		    params1.ParameterName = "p1";
		    params1.Value = model.m_id;

		    params2.ParameterName = "p2";
		    params2.Value = model.idOfSelectedGenres;

            
		    dbcommand.Parameters.Add(params1);
		    dbcommand.Parameters.Add(params2);
           

		    dbcommand.ExecuteReader();
		    dbcommand.Parameters.Clear();

		    return RedirectToAction("AddGenresToMovie", new { movie_id = model.m_id });
	    }

	    return View(model);
    }

   
}

