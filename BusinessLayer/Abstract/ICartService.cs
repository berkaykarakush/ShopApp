using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ICartService:IValidator<Cart>
    {
        void InitilazeCart(string userId);
        Cart GetCartByUserId(string userId);
        void AddToCart(string userId, double productId, int quantity);
        void DeleteFromCart(string userId, double productId);
        void ClearCart(double cartId);
    }
}
