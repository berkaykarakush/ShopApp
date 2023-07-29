using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(Product entity)
        {
            //TODO is kurallari uygula
            _productRepository.Create(entity);
        }

        public void Delete(Product entity)
        {
            //TODO is kurallari uygula
            _productRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            //TODO is kurallari uygula
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            //TODO is kurallari uygula
            return _productRepository.GetById(id);
        }

        public int GetCountByCategory(string category)
        {
            //TODO is kurallari
            return _productRepository.GetCountByCategory(category);
        }

        public List<Product> GetHomePageProducts()
        {
            //TODO is kurallari
            return _productRepository.GetHomePageProducts();
        }

        public Product GetProductDetails(string url)
        {
            //TODO is kurallari uygula
            return _productRepository.GetProductDetails(url);
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            //TODO is kurallari
            return _productRepository.GetProductsByCategory(name,page, pageSize);
        }

        public List<Product> GetSearchResult(string searchString)
        {
            //TODO is kurallari
            return _productRepository.GetSearchResult(searchString);
        }

        public void Update(Product entity)
        {
            //TODO is kurallari
            _productRepository.Update(entity);
        }
    }
}
