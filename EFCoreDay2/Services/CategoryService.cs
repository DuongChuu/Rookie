using EFCoreDay2.DTOs;
using EFCoreDay2.Models;
using EFCoreDay2.Repositories;

namespace EFCoreDay2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public AddCategoryResponse? Create(AddCategoryRequest requestModel)
        {
            using var transaction = _categoryRepo.DatabaseTransaction();

            try
            {
                var addCategory = new Category
                {
                    Id = requestModel.Id,
                    Name = requestModel.Name
                };

                var newCategory = _categoryRepo.Create(addCategory);
                _categoryRepo.SaveChanges();

                transaction.Commit();

                return new AddCategoryResponse
                {
                    Id = newCategory.Id,
                    Name = newCategory.Name,
                };
            }
            catch
            {
                transaction.RollBack();

                return null;
            }
        }

        public bool Delete(int id)
        {
            using var transaction = _categoryRepo.DatabaseTransaction();
            try
            {
                var categogy = _categoryRepo.Get(x => x.Id == id);

                if (categogy == null)
                {
                    return false;
                }

                _categoryRepo.Delete(categogy);

                _categoryRepo.SaveChanges();

                transaction.Commit();

                return true;
            }
            catch
            {
                transaction.RollBack();

                return false;
            }
        }

        public IEnumerable<GetCategoryResponse> GetAll()
        {
            return _categoryRepo.GetAll(x => true)
              .Select(category => new GetCategoryResponse
              {
                  Id = category.Id,
                  Name = category.Name
              });

        }

        public GetCategoryResponse? GetById(int id)
        {
            var category = _categoryRepo.Get(g => g.Id == id);

            if (category == null)
            {
                return null;
            }

            return new GetCategoryResponse
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public UpdateCategoryResponse? Update(UpdateCategoryRequest requestModel)
        {
            using var transaction = _categoryRepo.DatabaseTransaction();

            try
            {
                var category = _categoryRepo.Get(x => x.Id == requestModel.Id);

                if (category == null)
                {
                    return null;
                }

                category.Name = requestModel.Name;

                var updatedCategory = _categoryRepo.Update(category);

                _categoryRepo.SaveChanges();

                transaction.Commit();

                return new UpdateCategoryResponse
                {
                    Id = updatedCategory.Id,
                    Name = updatedCategory.Name
                };
            }
            catch
            {
                transaction.RollBack();

                return null;
            }

        }
    }
}