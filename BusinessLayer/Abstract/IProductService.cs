using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        Product GetByIdWithCategories(int id);
        List<Product> GetAll();
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);
        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        Product GetProductDetails(string url);
        void Create(Product entity);
        void Update(Product entity);
        void Update(Product entity, int[] categoryIds);
        void Delete(Product entity);
        int GetCountByCategory(string category);
    }
}
