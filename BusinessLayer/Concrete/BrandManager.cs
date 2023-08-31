using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string ErrorMessage { get; set; } = string.Empty;

        public bool Create(Brand entity)
        {
            bool isValid = false;
            if (Validation(entity))
            {
                _unitOfWork.Brands.Create(entity);
                _unitOfWork.Save();
                isValid = true;
            }
            return isValid;
        }

        public bool Delete(Brand entity)
        {
            bool isValid = false;

            if (Validation(entity))
            {
                _unitOfWork.Brands.Delete(entity);
                _unitOfWork.Save();
            }
            return isValid;
        }

        public List<Brand> GetAll()
        {
            return _unitOfWork.Brands.GetAll();
        }

        public Brand GetById(double id)
        {
            return _unitOfWork.Brands.GetById(id);
        }

        public bool Update(Brand entity)
        {
            bool isValid = false;

            if (Validation(entity))
            {
                _unitOfWork.Brands.Update(entity);
                _unitOfWork.Save();
            }
            return isValid;
        }

        public bool Validation(Brand entity)
        {
            bool isValid = true;

            if (entity != null)
            {
                if (string.IsNullOrEmpty(entity.Name))
                {
                    ErrorMessage += "Brand name is required";
                    isValid = false;
                }
            }
            else
                isValid = false;

            ErrorMessage += "Error - Null Reference!";
            return isValid;
        }
    }
}
