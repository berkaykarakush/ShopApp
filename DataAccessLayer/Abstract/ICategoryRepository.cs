using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryRepository : IRepository<Category>    
    {
        List<Product> GetPopularCategories();

    }
}
