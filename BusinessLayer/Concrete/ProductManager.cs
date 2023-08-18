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
            _unitOfWork.Products.Delete(entity);
            _unitOfWork.Save();
        }

        public List<Product> GetAll()
        {
            return _unitOfWork.Products.GetAll();
        }

        public Product GetById(double id)
        {
            return _unitOfWork.Products.GetById(id);
        }

        public Product GetByIdWithCategories(double id)
        {
            return _unitOfWork.Products.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _unitOfWork.Products.GetCountByCategory(category);
        }

        public int GetCountTopSalesProduct()
        {
           return _unitOfWork.Products.GetCountTopSalesProduct();
        }

        public List<Product> GetHomePageProducts()
        {
            return _unitOfWork.Products.GetHomePageProducts();
        }

        public Product GetProductDetails(string url)
        {
            return _unitOfWork.Products.GetProductDetails(url);
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            return _unitOfWork.Products.GetProductsByCategory(name,page, pageSize);
        }

        public List<Product> GetSearchResult(string searchString)
        {
            return _unitOfWork.Products.GetSearchResult(searchString);
        }

        public List<Product> GetTopSalesProducts(int page, int pageSize)
        {
            return _unitOfWork.Products.GetTopSalesProducts(page,pageSize);
        }

        public bool Update(Product entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.Products.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            ErrorMessage += "Lutfen eksik bilgileri giriniz.\n";
            return false;

        }
        public bool Update(Product entity, List<double> categoryIds)
        {
            if (categoryIds.Count() == 0)
            {
                ErrorMessage += "Urun icin en az bir kategori secmelisiniz.\n";
                return false;
            }
            _unitOfWork.Products.Update(entity, categoryIds);
            _unitOfWork.Save();
            return true;
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
            if (string.IsNullOrEmpty(entity.Description))
            {
                ErrorMessage += "Urun aciklamasi bos birakilamaz\n";
                isValid = false;
            }
            //if (entity.ImageUrls == null)
            //{
            //    ErrorMessage += "Urun resmi bos birakilamaz.\n";
            //    isValid = false;
            //}

            return isValid;
        }
    }
}
