using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IOrderService:IValidator<Order>, IService<Order>
    {
        List<Order> GetOrders(string userId);
    }
}
