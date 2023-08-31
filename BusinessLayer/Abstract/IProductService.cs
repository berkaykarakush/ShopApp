using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IProductService:IValidator<Product>, IService<Product>
    {
        Product GetByIdWithCategories(double id);
        List<Product> GetHomePageProducts();
        List<Product> GetTopSalesProducts(int page, int pageSize);
        List<Product> GetSearchResult(string searchString);
        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        Product GetProductDetails(string url);
        int GetCountByCategory(string category);
        int GetCountTopSalesProduct();
    }
}
