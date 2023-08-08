using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EFCoreOrderRepository : EFCoreGenericRepository<Order, ShopContext>, IOrderRepository
    {
        public List<Order> GetOrders(string userId)
        {
            using (var context = new ShopContext())
            {
                var orders = context.Orders
                    .Include(o => o.OrderItems)
                    .ThenInclude(o => o.Product)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(userId))
                    orders = orders.Where(o => o.UserId == userId);

                return orders.ToList();
            }
        }
    }
}
