using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public string ErrorMessage { get; set; }

        public void AddToCart(string userId, int productId, int quantity)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                //TODO eklenmek isteyen urun sepette var mi (update)
                //TODO eklenmek isteyen urun sepetta var ve yeni kayit olustur(insert)

                var index = cart.CartItems.FindIndex(c => c.ProductId == productId);
                if (index<0)
                {
                    cart.CartItems.Add(new CartItem() 
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CartId = cart.Id
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }
                _cartRepository.Update(cart);
            }
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                _cartRepository.DeleteFromCart(cart.Id, productId);
            }
        }

        public Cart GetCartByUserId(string userId)
        {
           return _cartRepository.GetByUserId(userId);
        }

        public void InitilazeCart(string userId)
        {
            _cartRepository.Create(new Cart() { UserId = userId});
        }

        public bool Validation(Cart entity)
        {
            throw new NotImplementedException();
        }
    }
}
