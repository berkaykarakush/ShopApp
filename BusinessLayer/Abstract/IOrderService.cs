using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IOrderService:IValidator<Order>
    {
        Order GetById(int id);
        List<Order> GetAll();
        void Create(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
    }
}
