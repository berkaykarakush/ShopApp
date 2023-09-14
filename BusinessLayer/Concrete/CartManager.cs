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

        public string ErrorMessage { get; set; } = string.Empty;

        public void AddToCart(string userId, double productId, int quantity)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                var product = _unitOfWork.Products.GetById(productId);
                var index = cart.CartItems.FindIndex(c => c.ProductId == productId);
                if (index<0)
                {
                    if (product.Quantity < quantity)
                    {
                        ErrorMessage += "Has no product\n";
                        cart.CartItems[index].Quantity = product.Quantity;
                    }

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

                    if (product.Quantity < cart.CartItems[index].Quantity)
                    {
                        ErrorMessage += "Has no product\n";
                        cart.CartItems[index].Quantity = product.Quantity;

                    }
                }

                _unitOfWork.Carts.Update(cart);
                _unitOfWork.Save();
            }
        }
        public Cart GetCartByUserId(string userId)
        {
            return _unitOfWork.Carts.GetByUserId(userId);
        }
        public void ClearCart(double cartId)
        {
            _unitOfWork.Carts.ClearCart(cartId);
            _unitOfWork.Save();
        }

        public void DeleteFromCart(string userId, double productId)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                var index = cart.CartItems.FindIndex(c => c.ProductId == productId);
                if (!(index < 0))
                {
                    if (cart.CartItems[index].Quantity == 1)
                        _unitOfWork.Carts.DeleteFromCart(cart.CartId, productId);
                    else
                        cart.CartItems[index].Quantity -= 1;
                }
            }
            _unitOfWork.Carts.Update(cart);
            _unitOfWork.Save();
        }
        public void InitilazeCart(string userId)
        {
            _unitOfWork.Carts.Create(new Cart() { UserId = userId});
            _unitOfWork.Save();
        }

        public bool Validation(Cart entity)
        {
            bool isValid = true;

            if(entity != null)
            {
                if (0 < entity.CartId)
                {
                    ErrorMessage += "CartId bilgisine erisilemedi lutfen tekrar deneyiniz.\n";
                    isValid = false;
                }
                if (entity.UserId == null)
                {
                    ErrorMessage += "UserId bilgisine erisilemdi lutfen tekrar deneyiniz.\n";
                    isValid = false;
                }
            }
            else
                isValid = false;

            ErrorMessage += "Error - Null reference!";
            return isValid;
        }
    }
}
