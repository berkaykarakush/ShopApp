using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductDetails(string url);
        Product GetByIdWithCategories(double id);
        Product GetByIdWithImageUrls(double id);
        List<Product> GetProductsByCategory(string name, int page, int pageSize); 
        List<Product> GetProductsByCategory2(string name, int page, int pageSize); 
        List<Product> GetProductByBrand(string name, int page, int pageSize);
        List<Product> GetPopularProducts();
        List<Product> GetTopSalesProducts(int page, int pageSize);
        List<Product> GetTopSalesProductsWithCategory(string name,int page, int pageSize);
        List<Product> GetSearchResult(string searchString);
        List<Product> GetHomePageProducts();
        int GetCountByCategory(string category);
        int GetCountByCategory2(string category2);
        int GetCountByBrand(string brand);
        int GetCountTopSalesProduct();
    }
}
