using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string ErrorMessage { get; set; } = string.Empty;

        public bool Create(Category entity)
        {
            bool isValid = true;
            if (!_unitOfWork.Categories.GetByName(entity.Name))
            {
                _unitOfWork.Categories.Create(entity);
                _unitOfWork.Save();
                isValid = true;
            }
            else 
            {
                ErrorMessage = "Girdiginiz isimde bir categori zaten mevcut";
                isValid = false;
            }
            return isValid;
        }

        public bool Delete(Category entity)
        {
            bool isValid = false;
            var category = _unitOfWork.Categories.GetById(entity.CategoryId);
            if (category != null)
            {
                _unitOfWork.Categories.Update(entity);
                _unitOfWork.Save();
                isValid = true;
            }
            return isValid;
        }

        public void DeleteFromCategory(double productId, double categoryId)
        {
            _unitOfWork.Categories.DeleteFromCategory(productId, categoryId);
            _unitOfWork.Save();
        }

        public List<Category> GetAll()
        {
           return _unitOfWork.Categories.GetAll();
        }

        public Category GetById(double id)
        {
            return _unitOfWork.Categories.GetById(id);
        }

        public Category GetByIdWithProducts(double categoryId)
        {
            return _unitOfWork.Categories.GetByIdWithProducts(categoryId);
        }

        public bool Update(Category entity)
        {
            bool isValid = false;
            var category = _unitOfWork.Categories.GetById(entity.CategoryId);
            if (category != null)
            {
                _unitOfWork.Categories.Update(entity);
                _unitOfWork.Save();
                isValid = true;
            }
            return isValid;
        }

        public bool Validation(Category entity)
        {
            bool isValid = true;
            if (entity != null)
            {
                if (string.IsNullOrEmpty(entity.Name))
                {
                    ErrorMessage += "Category ismi bos birakilamaz.\n";
                    isValid = false;
                }
                if (string.IsNullOrEmpty(entity.Url))
                {
                    ErrorMessage += "Category url alani bos birakilamaz.\n";
                    isValid = false;
                }
            }
            else
                isValid = false;

            ErrorMessage += "Error - Null reference!";
            return isValid;
        }
    }
}
