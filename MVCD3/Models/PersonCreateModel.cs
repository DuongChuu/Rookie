using System.ComponentModel.DataAnnotations;
namespace MVCD3.Models
{
    public class PersonCreateModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime DOB { get; set; }
        public string? Phone { get; set; }
        public string? BirthPlace { get; set; }
    }
}