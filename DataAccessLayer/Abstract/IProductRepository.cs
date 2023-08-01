using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductDetails(string url);
        Product GetByIdWithCategories(int id);
        List<Product> GetProductsByCategory(string name, int page, int pageSize); 
        List<Product> GetPopularProducts();
        List<Product> GetTop5Products();
        List<Product> GetSearchResult(string searchString);
        List<Product> GetHomePageProducts();
        int GetCountByCategory(string category);
        void Update(Product entity, int[] categoryIds);

    }
}
