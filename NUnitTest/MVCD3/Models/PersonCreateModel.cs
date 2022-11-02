using System.ComponentModel.DataAnnotations;
namespace MVCD3.Models
{
    public class PersonCreateModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? BirthPlace { get; set; }
    }
}