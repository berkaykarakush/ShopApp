using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class CheckoutQueryHandler : IRequestHandler<CheckoutQueryRequest, CheckoutQueryResponse>
    {
        public Task<CheckoutQueryResponse> Handle(CheckoutQueryRequest request, CancellationToken cancellationToken)
        {

            try
            {
                return Task.FromResult(new CheckoutQueryResponse() 
                {
                    Cart = new Cart()
                    {
                        CartId = request.Cart.CartId,
                        CartItems = request.Cart.CartItems.Select(c => new CartItem()
                        {
                            ProductId = c.ProductId,
                            CartItemId = c.ProductId,
                            ProductName = c.Product.Name,
                            Price = c.Product.Price,
                            Quantity = c.Quantity
                        }).ToList()
                    },
                    IsSuccess = true
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new CheckoutQueryResponse() { IsSuccess = false});
        }
    }
}
