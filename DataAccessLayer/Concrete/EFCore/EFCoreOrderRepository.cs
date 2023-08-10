using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreOrderRepository : EFCoreGenericRepository<Order>, IOrderRepository
    {
        public EFCoreOrderRepository(ShopContext context) : base(context)
        {}
        private ShopContext ShopContext
        {
            get { return _context as ShopContext; }
        }
        public List<Order> GetOrders(string userId)
        {
            var orders = ShopContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Product)
                .AsQueryable();

            if (!string.IsNullOrEmpty(userId))
                orders = orders.Where(o => o.UserId == userId);

            return orders.ToList();
        }
    }
}
