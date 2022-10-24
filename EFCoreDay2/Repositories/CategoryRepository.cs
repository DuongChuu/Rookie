using EFCoreDay2.Data;
using EFCoreDay2.Models;

namespace EFCoreDay2.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductStoreContext context) : base(context)
        {
        }
    }
}