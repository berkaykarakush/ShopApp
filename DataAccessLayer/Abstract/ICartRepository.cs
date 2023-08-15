using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface ICartRepository : IRepository<Cart>
    {
        void ClearCart(double cartId);
        void DeleteFromCart(double id, double productId);
        Cart GetByUserId(string userId);
    }
}
