using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Microsoft.IdentityModel.Abstractions;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommandRequest, AddToCartCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddToCartCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public Task<AddToCartCommandResponse> Handle(AddToCartCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var cart = _unitOfWork.Carts.GetByUserId(request.UserId ?? string.Empty);

                if (cart == null)
                    return Task.FromResult (new AddToCartCommandResponse() { IsSuccess = false});

                var product = _unitOfWork.Products.GetById(request.ProductId);

                if (product == null)
                    return Task.FromResult(new AddToCartCommandResponse() { IsSuccess = false });

                if (cart.CartItems == null)
                    return Task.FromResult(new AddToCartCommandResponse() { IsSuccess = false });

                var index = cart.CartItems.FindIndex(c => c.ProductId == request.ProductId);

                if (index < 0)
                {
                    if (product.Quantity < request.Quantity)
                        cart.CartItems[index].Quantity = product.Quantity;

                    cart.CartItems.Add(new CartItem()
                    {
                        ProductId = request.ProductId,
                        Product = product,
                        Quantity = request.Quantity,
                        CartId = cart.CartId
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += request.Quantity;

                    if (product.Quantity < cart.CartItems[index].Quantity)
                        cart.CartItems[index].Quantity = product.Quantity;
                }

                decimal totalPrice = 0m;
                foreach (var item in cart.CartItems)
                {
                    totalPrice += item.Product.Price * item.Quantity;
                }
                cart.TotalPrice = totalPrice;

                _unitOfWork.Carts.Update(cart);
                _unitOfWork.Save();

                return Task.FromResult(new AddToCartCommandResponse() { IsSuccess = true, Url = product.Url });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new AddToCartCommandResponse() { IsSuccess = false });
        }
    }
}
