using DataAccessLayer.Abstract;
using EntityLayer;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreCategoryRepository : EFCoreGenericRepository<Category, ShopContext>, ICategoryRepository
    {
        public List<Product> GetPopularCategories()
        {
            throw new NotImplementedException();
        }
    }
}
