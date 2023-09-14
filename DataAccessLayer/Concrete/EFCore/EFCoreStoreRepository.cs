using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreStoreRepository : EFCoreGenericRepository<Store>, IStoreRepository
    {
        public EFCoreStoreRepository(ShopContext context) : base(context)
        {
        }

        private ShopContext ShopContext { get { return _context as ShopContext; } }
        public Store GetByIdWithImageUrls(double id)
        {
            return ShopContext.Stores
                            .Where(s => s.StoreId == id)
                            .Include(s => s.ImageUrls)
                            .FirstOrDefault();
        }

        public Store GetByUserIdWithImageUrls(string userId)
        {
            return ShopContext.Stores
                            .Where(s => s.SellerId == userId)
                            .Include(s => s.ImageUrls)
                            .FirstOrDefault();
        }

        public Store GetStore(string userId)
        {
            return ShopContext.Stores
                .Where(s => s.SellerId == userId)
                .Include(s => s.Orders)
                .FirstOrDefault();
        }

        public Store GetStoreByStoreUrl(string storeUrl)
        {
            return ShopContext.Stores
                .Where(s => s.StoreUrl == storeUrl)
                .Include(s => s.ImageUrls)
                .FirstOrDefault();
        }
    }
}
