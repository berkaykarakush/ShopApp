using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class Category2Manager : ICategory2Service
    {
        private readonly IUnitOfWork _unitOfWork;

        public Category2Manager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string ErrorMessage { get; set; } = string.Empty;

        public bool Create(Category2 entity)
        {
            bool isValid = false;
            if (Validation(entity))
            {
                _unitOfWork.Categories2.Create(entity);
                _unitOfWork.Save();
                isValid = true;
            }
            return isValid;
        }

        public bool Delete(Category2 entity)
        {
            bool isValid = false;
            if (Validation(entity))
            {
                _unitOfWork.Categories2.Delete(entity);
                _unitOfWork.Save();
                isValid = true;
            }
            return isValid;
        }

        public List<Category2> GetAll()
        {
            return _unitOfWork.Categories2.GetAll();
        }

        public Category2 GetById(double id)
        {
            return _unitOfWork.Categories2.GetById(id);
        }

        public Category2 GetByIdWithProducts(double category2Id)
        {
            return _unitOfWork.Categories2.GetByIdWithProducts(category2Id);
        }

        public bool Update(Category2 entity)
        {
            bool isValid = false;
            if (Validation(entity))
            {
                _unitOfWork.Categories2.Update(entity);
                _unitOfWork.Save();
                isValid = true;
            }
            return isValid;
        }

        public bool Validation(Category2 entity)
        {
            bool isValid = true;

            if (entity != null)
            {
                if (string.IsNullOrEmpty(entity.Name))
                {
                    ErrorMessage += "Name is required";
                    isValid = false;
                }
                if (string.IsNullOrEmpty(entity.Url))
                {
                    ErrorMessage += "Url is required";
                    isValid = false;
                }
            }
            else
                isValid = false;
            
            return isValid;
        }
    }
}
