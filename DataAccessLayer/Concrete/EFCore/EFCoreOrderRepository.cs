using DataAccessLayer.Abstract;
using EntityLayer;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreOrderRepository : EFCoreGenericRepository<Order, ShopContext>, IOrderRepository
    {
    }
}
