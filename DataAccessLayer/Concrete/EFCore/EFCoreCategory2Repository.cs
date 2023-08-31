using DataAccessLayer.Abstract;
using EntityLayer;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreCategory2Repository : EFCoreGenericRepository<Category2>, ICategory2Repository
    {
        public EFCoreCategory2Repository(ShopContext context) : base(context)
        {
        }
        private ShopContext ShopContext { get { return _context as ShopContext; } }
    }
}
