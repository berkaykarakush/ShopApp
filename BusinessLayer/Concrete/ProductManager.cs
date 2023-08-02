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

        public string ErrorMessage { get; set; }

        public bool Create(Product entity)
        {
            //TODO is kurallari uygula
            if (Validation(entity))
            {
                _productRepository.Create(entity);
                return true;
            }
            return false;
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

        public Product GetByIdWithCategories(int id)
        {
            //TODO is kurallari uygula
            return _productRepository.GetByIdWithCategories(id);
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

        public bool Update(Product entity, int[] categoryIds)
        {
            //TODO is kurallari
            if (Validation(entity))
            {
                if (categoryIds.Length == 0)
                {
                    ErrorMessage += "Urun icin en az bir kategori secmelisiniz.\n";
                    return false;
                }
                _productRepository.Update(entity, categoryIds);
                return true;
            }
            return false;
        }

        public bool Validation(Product entity)
        {
            var isValid = true;
            
            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "urun ismi bos birakilamaz.\n";
                isValid = false;
            }
            if (entity.Price < 1)
            {
                ErrorMessage += "urun fiyati 1'den az olamaz.\n";
                isValid = false;
            }

            return isValid;
        }
    }
}
