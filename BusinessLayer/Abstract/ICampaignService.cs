using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ICampaignService : IValidator<Campaign>
    {
        Campaign GetById(double id);
        List<Campaign> GetAll();
        bool Create(Campaign entity);
        bool Update(Campaign entity);
        void Delete(Campaign entity);
    }
}
