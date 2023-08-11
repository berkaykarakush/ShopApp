using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IOrderService:IValidator<Order>
    {
        Order GetById(int id);
        List<Order> GetAll();
        List<Order> GetOrders(string userId);
        bool Create(Order entity);
        bool Update(Order entity);
        bool Delete(Order entity);
    }
}
