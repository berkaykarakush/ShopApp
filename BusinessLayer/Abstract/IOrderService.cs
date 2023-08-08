using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IOrderService:IValidator<Order>
    {
        Order GetById(int id);
        List<Order> GetAll();
        List<Order> GetOrders(string userId);
        void Create(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
    }
}
