using System.ComponentModel.DataAnnotations;

namespace streaming_service.Models;

public class RegisterModel : IValidatableObject
{
    [Required] public string Login { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "username")]
    public string Username { get; set; }
    

    [Required]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [StringLength(30, MinimumLength = 6, ErrorMessage = "Length of Password should be between 6 and 30 letters")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Passwords doesn't match")]
    public string ConfirmPassword { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date Of Birth")]
    public DateTime DateOfBirth { get; set; }
    
    [Required]

    [DataType(DataType.Text)]
    [Display(Name = "Gender")]
    public string Gender { get; set; }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();

        if (Username.Any(x => char.IsDigit(x))) errors.Add(new ValidationResult("Name can't contain digits"));
        
        return errors;
    }
}