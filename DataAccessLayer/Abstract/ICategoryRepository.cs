using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryRepository : IRepository<Category>    
    {
        List<Product> GetPopularCategories();
        Category GetByIdWithProducts(int categoryId);
        void DeleteFromCategory(int productId, int categoryId);

    }
}
