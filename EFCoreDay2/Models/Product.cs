using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreDay2.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public string? ProductName { get; set; }
        [Required]
        [StringLength(100)]
        public string? Manufacture { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}