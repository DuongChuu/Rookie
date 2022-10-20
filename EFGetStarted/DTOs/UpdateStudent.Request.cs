using System.ComponentModel.DataAnnotations;

namespace EFGetStarted.DTOs
{
    public class UpdateStudentRequest
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
    }
}