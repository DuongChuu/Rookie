using System.ComponentModel.DataAnnotations;

namespace EFCoreDay2.DTOs
{
    public class UpdateProductRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? ProductName { get; set; }
        [Required]
        [StringLength(100)]
        public string? Manufacture { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}