using EntityLayer;

namespace DataAccessLayer.Abstract
{
    public interface ICartRepository : IRepository<Cart>
    {
        void DeleteFromCart(int id, int productId);
        Cart GetByUserId(string userId);
    }
}
