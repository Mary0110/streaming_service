using System.ComponentModel.DataAnnotations;

namespace streaming_service.Models.Admin;

public class AddDirectorModel
{
    [Required]
    [DataType(DataType.Text)] 
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Text)] 
    public string Surname { get; set; }

    [Required] 
    [DataType(DataType.Date)] 
    public DateTime DateOfBirth { get; set; }

    [Required] 
    [DataType(DataType.Text)]
    public string Gender { get; set; }
    
}

public enum Gender
{
    MALE = 0,
    FEMALE = 1,
    NON_BINARY = 2
}