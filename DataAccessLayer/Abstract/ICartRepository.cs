using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface ICartRepository : IRepository<Cart>
    {
        void ClearCart(int cartId);
        void DeleteFromCart(int id, int productId);
        Cart GetByUserId(string userId);
    }
}
