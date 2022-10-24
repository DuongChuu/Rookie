using EFCoreDay2.DTOs;

namespace EFCoreDay2.Services
{
    public interface ICategoryService
    {
        IEnumerable<GetCategoryResponse> GetAll();
        GetCategoryResponse? GetById(int id);
        AddCategoryResponse? Create(AddCategoryRequest requestModel);
        UpdateCategoryResponse? Update(UpdateCategoryRequest requestModel);
        bool Delete(int id);
    }
}