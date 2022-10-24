using System.ComponentModel.DataAnnotations;

namespace EFCoreDay2.DTOs
{
    public class UpdateCategoryRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; } 
    }
}