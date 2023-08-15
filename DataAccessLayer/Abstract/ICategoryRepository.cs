using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryRepository : IRepository<Category>    
    {
        List<Product> GetPopularCategories();
        Category GetByIdWithProducts(double categoryId);
        void DeleteFromCategory(double productId, double categoryId);
        bool GetByName(string name);
    }
}
