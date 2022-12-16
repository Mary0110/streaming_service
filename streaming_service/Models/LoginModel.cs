using System.ComponentModel.DataAnnotations;

namespace streaming_service.Models;

public class LoginModel 
{
    [Required(ErrorMessage = "Login?")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Password?")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}