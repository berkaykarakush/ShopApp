using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class CampaignManager : ICampaignService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CampaignManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string ErrorMessage { get; set; } = string.Empty;

        public bool Create(Campaign entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.Campaigns.Create(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public void Delete(Campaign entity)
        {
            _unitOfWork.Campaigns.Delete(entity);
            _unitOfWork.Save();
        }

        public List<Campaign> GetAll()
        {
            return _unitOfWork.Campaigns.GetAll();
        }

        public Campaign GetById(double id)
        {
            return _unitOfWork.Campaigns.GetById(id);
        }
        public bool Update(Campaign entity)
        {
            if (Validation(entity))
            {
                _unitOfWork.Campaigns.Update(entity);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool Validation(Campaign entity)
        {
            bool isValid = true;
            if (entity != null)
            {
                if (string.IsNullOrEmpty(entity.Name))
                {
                    ErrorMessage += "Campaign name is not null!";
                    isValid = false;
                }
                if (string.IsNullOrEmpty(entity.Description))
                {
                    ErrorMessage += "Campaign description is not null!";
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
