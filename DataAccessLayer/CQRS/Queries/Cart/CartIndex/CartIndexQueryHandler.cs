using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;
using System.IO.Pipes;

namespace DataAccessLayer.CQRS.Queries
{
    public class CartIndexQueryHandler : IRequestHandler<CartIndexQueryRequest, CartIndexQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartIndexQueryHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public  Task<CartIndexQueryResponse> Handle(CartIndexQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var cart = _unitOfWork.Carts.GetByUserId(request.UserId ?? string.Empty);

                if (cart == null)
                    return Task.FromResult(new CartIndexQueryResponse() { IsSuccess = false });

                return Task.FromResult(new CartIndexQueryResponse() 
                {
                    CartId = cart.CartId,
                    CartItems = cart.CartItems.Select(c => new CartItem()
                    {
                        Stock = c.Product.Quantity,
                        ProductId = c.ProductId,
                        CartItemId = c.ProductId,
                        Product = c.Product,
                        Price = c.Product.Price,
                        ProductName = c.Product.Name,
                        Quantity = c.Quantity,
                        ProductImage = c.Product.ProductImage
                    }).ToList(),
                    TotalPrice = cart.TotalPrice,
                    IsSuccess = true
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new CartIndexQueryResponse() { IsSuccess =false});
        }
    }
}
