using EFCoreDay2.DTOs;

namespace EFCoreDay2.Services
{
    public interface IProductService
    {
        IEnumerable<GetProductRespone> GetAll();
        GetProductRespone? GetById(int id);
        AddProductResponse? Create(AddProductRequest requestModel);
        UpdateProductResponse? Update(UpdateProductRequest requestModel);
        bool Delete(int id);
    }
}