namespace Assignment6.Models;

    public class PersonModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime DOB { get; set; }
        public string? Phone { get; set; }
        public string? BirthPlace { get; set; }
        public bool IsGraduated { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DOB.Year;
            }
        }
        public string FullName
        {
            get
            {
                return FirstName + LastName;
            }
        }
          public PersonModel(string firstName, string lastName, string gender, DateTime dob, string number, string birthPlace, bool isGraduated)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DOB = dob;
            Phone = number;
            BirthPlace = birthPlace;
            IsGraduated = isGraduated;
        }
    }
