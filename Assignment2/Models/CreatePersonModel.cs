using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models;

public class CreatePersonModel
{
    [Required]
    public string? FirstName { get; set; } 
    [Required]
    public string? LastName { get; set; } 
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    public string? Gender { get; set; } 
    [Required]
    public string? BirthPlace { get; set; } 
}