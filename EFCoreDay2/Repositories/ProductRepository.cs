using EFCoreDay2.Data;
using EFCoreDay2.Models;

namespace EFCoreDay2.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductStoreContext context) : base(context)
        {
        }
    }
}