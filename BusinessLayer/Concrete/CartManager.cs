using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class CartManager : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                        CartId = cart.CartId
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }
                _unitOfWork.Carts.Update(cart);
                _unitOfWork.Save();
            }
        }

        public void ClearCart(int cartId)
        {
            _unitOfWork.Carts.ClearCart(cartId);
            _unitOfWork.Save();
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                _unitOfWork.Carts.DeleteFromCart(cart.CartId, productId);
                _unitOfWork.Save();
            }
        }

        public Cart GetCartByUserId(string userId)
        {
           return _unitOfWork.Carts.GetByUserId(userId);
        }

        public void InitilazeCart(string userId)
        {
            _unitOfWork.Carts.Create(new Cart() { UserId = userId});
            _unitOfWork.Save();
        }

        public bool Validation(Cart entity)
        {
            throw new NotImplementedException();
        }
    }
}
