using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface ICampaignRepository: IRepository<Campaign>
    {
        Campaign GetByCode(string code);
    }
}
