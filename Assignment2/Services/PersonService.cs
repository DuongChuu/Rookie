using Assignment2.Models;

namespace Assignment2.Services;

public class PersonService : IPersonService
{
    private static readonly List<PersonModel> _peopleList = new()
    {
        new PersonModel( "Duong","Chu",new DateTime(2000,01,11),"Male","HaNoi"),
        new PersonModel( "Duong","Huong",new DateTime(2001,12,11), "Female","Hai Duong"),
        new PersonModel( "Pham","ThieuAnh",new DateTime(2003,09,11),"Female","Bac Giang"),
        new PersonModel( "Trinh","HoangAnh",new DateTime(2004,08,09), "Male,","Hai Phong"),
        new PersonModel( "Nguyen","Hung",new DateTime(1999,01,01),"Male","Ha noi" ),
    };

    public PersonModel? Create(CreatePersonModel createModel)
    {
        if (createModel.FirstName != null && createModel.LastName != null
        && createModel.DateOfBirth != null && createModel.BirthPlace != null
        && createModel.Gender != null)
        {
            var createItem = new PersonModel(
                createModel.FirstName,
                createModel.LastName,
                createModel.DateOfBirth,
                createModel.Gender,
                createModel.BirthPlace);

            _peopleList.Add(createItem);

            return createItem;
        }
        else
        {
            return null;
        }
    }

    public bool Delete(Guid id)
    {
        var entity = _peopleList.First(person => person.Id == id);

        return _peopleList.Remove(entity);
    }

    public IEnumerable<PersonModel> GetAll(string? name, string? gender, string? birthPlace)
    {
        var item = _peopleList.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            item = item.Where(person => person.FullName == name);
        }

        if (!string.IsNullOrEmpty(gender))
        {
            item = item.Where(person => person.Gender == gender);
        }

        if (!string.IsNullOrEmpty(birthPlace))
        {
            item = item.Where(person => person.BirthPlace == birthPlace);
        }

        return item;
    }

    public bool IsExist(Guid id)
    {
        return _peopleList.Any(person => person.Id == id);
    }

    public PersonModel? Update(Guid id, UpdatePersonModel updateModel)
    {
        var item = _peopleList.First(person => person.Id == id);
        if (updateModel.FirstName != null && updateModel.LastName != null
        && updateModel.DateOfBirth != null && updateModel.BirthPlace != null
        && updateModel.Gender != null)
        {
            item.FirstName = updateModel.FirstName;
            item.LastName = updateModel.LastName;
            item.DateOfBirth = updateModel.DateOfBirth;
            item.BirthPlace = updateModel.BirthPlace;
            item.Gender = updateModel.Gender;

            return item;
        }
        else
        {
            return null;
        }
    }
}