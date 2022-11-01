namespace Assignment2.Models;
public class PersonModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string BirthPlace { get; set; }
    public string FullName
    {
        get
        {
            return FirstName + " " + LastName;
        }
    }

    public PersonModel(
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string gender,
        string birthPlace
    )
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        BirthPlace = birthPlace;
        Gender = gender;
    }
}