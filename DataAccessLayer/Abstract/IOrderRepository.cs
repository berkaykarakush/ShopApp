using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetOrders(string userId);
        Order GetByOrderWithOrderItems(double orderId);

    }
}
