using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class CartIndexQueryHandler : IRequestHandler<CartIndexQueryRequest, CartIndexQueryResponse>
    {
        public  Task<CartIndexQueryResponse> Handle(CartIndexQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var cart = request.Cart;

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
