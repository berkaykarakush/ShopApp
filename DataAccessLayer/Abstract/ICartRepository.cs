using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface ICartRepository : IRepository<Cart>
    {
        void ClearCart(double cartId);
        void DeleteFromCart(double cartId, double productId);
        Cart GetByUserId(string userId);
        Cart GetCartWithCartItems(double cartId);
    }
}
