using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string ErrorMessage { get; set; }

        public bool Create(Product entity)
        {
            //TODO is kurallari uygula
            if (Validation(entity))
            {
                _unitOfWork.Products.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public void Delete(Product entity)
        {
            //TODO is kurallari uygula
            _unitOfWork.Products.Delete(entity);
            _unitOfWork.Save();
        }

        public List<Product> GetAll()
        {
            //TODO is kurallari uygula
            return _unitOfWork.Products.GetAll();
        }

        public Product GetById(int id)
        {
            //TODO is kurallari uygula
            return _unitOfWork.Products.GetById(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            //TODO is kurallari uygula
            return _unitOfWork.Products.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            //TODO is kurallari
            return _unitOfWork.Products.GetCountByCategory(category);
        }

        public List<Product> GetHomePageProducts()
        {
            //TODO is kurallari
            return _unitOfWork.Products.GetHomePageProducts();
        }

        public Product GetProductDetails(string url)
        {
            //TODO is kurallari uygula
            return _unitOfWork.Products.GetProductDetails(url);
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            //TODO is kurallari
            return _unitOfWork.Products.GetProductsByCategory(name,page, pageSize);
        }

        public List<Product> GetSearchResult(string searchString)
        {
            //TODO is kurallari
            return _unitOfWork.Products.GetSearchResult(searchString);
        }

        public void Update(Product entity)
        {
            //TODO is kurallari
            _unitOfWork.Products.Update(entity);
            _unitOfWork.Save();
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
                _unitOfWork.Products.Update(entity, categoryIds);
                _unitOfWork.Save();
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
