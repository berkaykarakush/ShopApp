using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class CartIndexQueryHandler : IRequestHandler<CartIndexQueryRequest, CartIndexQueryResponse>
    {
        public async Task<CartIndexQueryResponse> Handle(CartIndexQueryRequest request, CancellationToken cancellationToken)
        {
            var cart = request.Cart;

            try
            {
                return new CartIndexQueryResponse()
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
                };
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return new CartIndexQueryResponse() { IsSuccess = false };
            }
        }
    }
}
