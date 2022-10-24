using EFCoreDay2.DTOs;
using EFCoreDay2.Models;
using EFCoreDay2.Repositories;

namespace EFCoreDay2.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        public ProductService(IProductRepository productRepo, ICategoryRepository cateRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = cateRepo;
        }

        public AddProductResponse? Create(AddProductRequest CreateModel)
        {
            using var transaction = _productRepo.DatabaseTransaction();
            try
            {
                var category = _categoryRepo.Get(s => s.Id == CreateModel.CategoryId);
                if (category == null)
                {
                    return null;
                }
                var product = new Product
                {
                    ProductId = CreateModel.Id,
                    ProductName = CreateModel.Name,
                    Manufacture = CreateModel.Manufacture,
                    CategoryId = CreateModel.CategoryId
                };
                var newProduct = _productRepo.Create(product);

                _productRepo.SaveChanges();

                transaction.Commit();

                return new AddProductResponse
                {
                    ProductId = newProduct.ProductId,
                    Name = newProduct.ProductName
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
            using var transaction = _productRepo.DatabaseTransaction();

            try
            {
                var product = _productRepo.Get(x => x.ProductId == id);

                if (product != null)
                {
                    _productRepo.Delete(product);

                    _productRepo.SaveChanges();
                }
                transaction.Commit();

                return true;
            }
            catch
            {
                transaction.RollBack();

                return false;
            }

        }

        public IEnumerable<GetProductRespone> GetAll()
        {
            var resultView = _productRepo.GetAll(x => true)
              .Select(category => new GetProductRespone
              {
                  Id = category.ProductId,
                  ProductName = category.ProductName,
                  Manufacture = category.Manufacture,
                  CategoryId = category.CategoryId
              });

            return resultView;
        }

        public GetProductRespone? GetById(int id)
        {
            var product = _productRepo.Get(x => x.ProductId == id);

            if (product == null)
            {
                return null;
            }

            return new GetProductRespone
            {
                Id = product.ProductId,
                ProductName = product.ProductName,
                Manufacture = product.Manufacture,
                CategoryId = product.CategoryId
            };
        }

        public UpdateProductResponse? Update(UpdateProductRequest requestModel)
        {

            using var transaction = _productRepo.DatabaseTransaction();

            try
            {
                var product = _productRepo.Get(x => x.ProductId == requestModel.Id);

                if (product == null)
                {
                    return null;
                }

                var category = _categoryRepo.Get(c => c.Id == requestModel.CategoryId);

                if (category == null)
                {
                    return null;
                }
                product.ProductName = requestModel.ProductName;
                product.Manufacture = requestModel.Manufacture;
                product.CategoryId = requestModel.CategoryId;

                var updatedProduct = _productRepo.Update(product);

                _productRepo.SaveChanges();

                transaction.Commit();

                return new UpdateProductResponse
                {
                    Id = updatedProduct.ProductId,
                    ProductName = updatedProduct.ProductName,
                    Manufacture = product.Manufacture,
                    CategoryId = product.CategoryId
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