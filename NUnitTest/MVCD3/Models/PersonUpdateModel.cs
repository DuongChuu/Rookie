using System.ComponentModel.DataAnnotations;
namespace MVCD3.Models
{
    public class PersonUpdateModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? BirthPlace { get; set; }
    }
}