using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models;

public class CreateTaskModel
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public bool IsCompleted { get; set; }
}