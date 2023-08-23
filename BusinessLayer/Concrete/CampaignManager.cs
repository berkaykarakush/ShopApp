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

        public string ErrorMessage { get; set; }

        public bool Create(Campaign entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Campaign entity)
        {
            throw new NotImplementedException();
        }

        public List<Campaign> GetAll()
        {
            return _unitOfWork.Campaigns.GetAll();
        }

        public Campaign GetById(double id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Campaign entity)
        {
            throw new NotImplementedException();
        }

        public bool Validation(Campaign entity)
        {
            throw new NotImplementedException();
        }
    }
}
