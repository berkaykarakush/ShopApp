using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductDetails(string url);
        Product GetByIdWithCategories(double id);
        List<Product> GetProductsByCategory(string name, int page, int pageSize); 
        List<Product> GetPopularProducts();
        List<Product> GetTopSalesProducts(int page, int pageSize);
        List<Product> GetTopSalesProductsWithCategory(string name,int page, int pageSize);
        List<Product> GetSearchResult(string searchString);
        List<Product> GetHomePageProducts();
        int GetCountByCategory(string category);
        int GetCountTopSalesProduct();
        void Update(Product entity, double[] categoryIds);
    }
}
