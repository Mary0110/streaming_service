using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using streaming_service.Entities;

namespace streaming_service.Models.Admin;

public class AddMovieModel //: IValidatableObject
{
  
    
    [Required]
    [DataType(DataType.Text)]
    public string MovieName { get; set; }
    
    [Required]
    [DataType(DataType.Duration)]
    public TimeSpan Time { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    public string? Description { get; set; }
    
    [Required]
    public bool SubtitlesAvailable { get; set; }
    
    [Required]
    [RegularExpression(@"^(19|20)\d{2}$", ErrorMessage = "Please enter a 4 digit year")]

    public string Year{ get; set; }
    
    [Required]
    [Range(0, 18, ErrorMessage = "Please, enter valid age")]
    public uint AgeRestriction { get; set; }


    public uint idForEdit { get; set; }
    
    // public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    // {
    //     var errors = new List<ValidationResult>();
    //
    //     if (CostForDay(x => char.IsDigit(x))) errors.Add(new ValidationResult("Name can't contain digits"));
    //
    //     if (LastName.Any(x => char.IsDigit(x))) errors.Add(new ValidationResult("Surname can't contain digits"));
    //
    //     if (Patronymic.Any(x => char.IsDigit(x))) errors.Add(new ValidationResult("Patronymic can't contain digits"));
    //
    //     return errors;
    // }
    
}