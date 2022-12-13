using System.ComponentModel.DataAnnotations;

namespace streaming_service.Models;

public class AddDirectorModel
{
    [Required]
    [DataType(DataType.Text)] 
    public double Name { get; set; }

    [Required]
    [DataType(DataType.Text)] 
    public int Surname { get; set; }

    [Required] 
    [DataType(DataType.Date)] 
    public DateTime Date { get; set; }

    [Required] 
    public Gender Gender { get; set; }
    
}

public enum Gender
{
    MALE,
    FEMALE,
    NON_BINARY
}