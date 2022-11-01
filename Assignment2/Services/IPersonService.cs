using Assignment2.Models;

namespace Assignment2.Services;

public interface IPersonService
{
    IEnumerable<PersonModel> GetAll(string? name, string? gender, string? birthPlace);
    PersonModel? Create(CreatePersonModel createModel);
    PersonModel? Update(Guid id, UpdatePersonModel updateModel);
    bool Delete(Guid id);
    bool IsExist(Guid id);
}