using System.ComponentModel.DataAnnotations;
namespace MVCD3.Models
{
    public class PersonUpdateModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? BirthPlace { get; set; }
    }
}