using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class StoreManager : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StoreManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string ErrorMessage { get; set; } = string.Empty;

        public bool Create(Store entity)
        {
            bool isValid = false;
            if (Validation(entity)) 
            {
                _unitOfWork.Stores.Create(entity);
                _unitOfWork.Save();
                isValid = true;
            }
            return isValid;
        }

        public bool Delete(Store entity)
        {
            bool isValid = false;
            if (Validation(entity))
            {
                _unitOfWork.Stores.Delete(entity);
                _unitOfWork.Save();
                isValid = true;
            }
            return isValid;
        }

        public List<Store> GetAll()
        {
            return _unitOfWork.Stores.GetAll();
        }

        public Store GetById(double id)
        {
            return _unitOfWork.Stores.GetById(id);
        }

        public bool Update(Store entity)
        {
            bool isValid = false;
            if (Validation(entity))
            {
                _unitOfWork.Stores.Update(entity);
                _unitOfWork.Save();
                isValid = true;
            }
            return isValid;
        }

        public bool Validation(Store entity)
        {
            bool isValid = true;
            if (entity != null)
            {
                if (string.IsNullOrEmpty(entity.SellerFirstName))
                {
                    ErrorMessage += "FirstName is required!";
                    isValid = false;
                }
                if (string.IsNullOrEmpty(entity.SellerLastName))
                {
                    ErrorMessage += "LastName is required!";
                    isValid = false;
                }
                if (string.IsNullOrEmpty(entity.StoreName))
                {
                    ErrorMessage += "Store Name is required!";
                    isValid = false;
                }
                if (string.IsNullOrEmpty(entity.SellerId))
                {
                    ErrorMessage += "SellerId is required!";
                    isValid = false;
                }
                if (string.IsNullOrEmpty(entity.SellerPhone))
                {
                    ErrorMessage += "Phone is required!";
                    isValid = false;
                }
            }
            else
                isValid = false;

            return isValid;
        }
    }
}
