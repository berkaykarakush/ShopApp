using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class CheckoutQueryHandler : IRequestHandler<CheckoutQueryRequest, CheckoutQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckoutQueryHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public Task<CheckoutQueryResponse> Handle(CheckoutQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var cart = _unitOfWork.Carts.GetByUserId(request.UserId ?? string.Empty);

                if (cart == null)
                    return Task.FromResult(new CheckoutQueryResponse() { IsSuccess = false });
                List<double> storeIds = new List<double>();
                foreach (var item in cart.CartItems)
                {
                    storeIds.Add((double)item.Product.StoreId);
                }


                return Task.FromResult(new CheckoutQueryResponse() 
                {
                    Cart = new Cart()
                    {
                        CartId = cart.CartId,
                        CartItems = cart.CartItems.Select(c => new CartItem()
                        {
                            ProductId = c.ProductId,
                            CartItemId = c.ProductId,
                            ProductName = c.Product.Name,
                            Price = c.Product.Price,
                            Quantity = c.Quantity
                        }).ToList()
                    },
                    IsSuccess = true,
                    StoreIds = storeIds
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
