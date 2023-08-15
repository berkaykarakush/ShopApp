using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IProductService:IValidator<Product>
    {
        Product GetById(double id);
        Product GetByIdWithCategories(double id);
        List<Product> GetAll();
        List<Product> GetHomePageProducts();
        List<Product> TopSales();
        List<Product> GetSearchResult(string searchString);
        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        Product GetProductDetails(string url);
        bool Create(Product entity);
        bool Update(Product entity);
        bool Update(Product entity, double[] categoryIds);
        void Delete(Product entity);
        int GetCountByCategory(string category);
    }
}
