using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreCampaignRepository : EFCoreGenericRepository<Campaign>, ICampaignRepository
    {
        public EFCoreCampaignRepository(ShopContext context) : base(context)
        {
        }
        private ShopContext? ShopContext
        {
            get { return _context as ShopContext; }
        }
    }
}
