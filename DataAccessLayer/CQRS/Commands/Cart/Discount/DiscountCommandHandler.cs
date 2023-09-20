using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class DiscountCommandHandler : IRequestHandler<DiscountCommandRequest, DiscountCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiscountCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public Task<DiscountCommandResponse> Handle(DiscountCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var cart = _unitOfWork.Carts.GetCartWithCartItems(request.CartId);
                
                if (cart == null)
                    return Task.FromResult(new DiscountCommandResponse() { IsSuccess = false });

                decimal totalPrice = 0m;
                foreach (var item in cart.CartItems)
                {
                    item.Price += item.Product.Price * item.Quantity;
                    totalPrice += item.Price;
                }
                cart.TotalPrice = 0;
                cart.TotalPrice = totalPrice;

                var campaign = _unitOfWork.Campaigns.GetByCode(request.Code ?? string.Empty);

                if (campaign == null)
                    return Task.FromResult(new DiscountCommandResponse() { IsSuccess = false });

                //total price 50
                //discount percantage %25
                // new total price = 50 - ((50 * 25) / 100) = 37.5
                decimal newTotalPrice = cart.TotalPrice - ((cart.TotalPrice * campaign.DiscountPercentage) / 100);

                cart.TotalPrice = newTotalPrice;

                _unitOfWork.Carts.Update(cart);
                _unitOfWork.Save();
                return Task.FromResult(new DiscountCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new DiscountCommandResponse() { IsSuccess = false });
        }
    }
}
