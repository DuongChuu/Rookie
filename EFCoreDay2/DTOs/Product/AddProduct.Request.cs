using System.ComponentModel.DataAnnotations;

namespace EFCoreDay2.DTOs
{
    public class AddProductRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        [StringLength(100)]
        public string? Manufacture { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}