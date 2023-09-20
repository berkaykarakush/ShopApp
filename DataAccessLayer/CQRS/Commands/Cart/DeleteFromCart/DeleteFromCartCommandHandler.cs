using DataAccessLayer.Abstract;
using MediatR;
using Microsoft.SqlServer.Server;
using Serilog;
using System.Security.AccessControl;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteFromCartCommandHandler : IRequestHandler<DeleteFromCartCommandRequest, DeleteFromCartCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFromCartCommandHandler(IUnitOfWork unitOfWork)
            =>    _unitOfWork = unitOfWork;

        public Task<DeleteFromCartCommandResponse> Handle(DeleteFromCartCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var productId = request.ProductId;
                var userId = request.UserId;

                if (userId == null || productId < 0)
                    return Task.FromResult(new DeleteFromCartCommandResponse() { IsSuccess = false });

                var cart = _unitOfWork.Carts.GetByUserId(userId);

                if (cart == null)
                    return Task.FromResult(new DeleteFromCartCommandResponse() { IsSuccess = false });


                if (cart.CartItems != null)
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

                foreach (var item in cart.CartItems)
                    cart.TotalPrice -= item.Product.Price;

                _unitOfWork.Carts.Update(cart);
                _unitOfWork.Save();
                return Task.FromResult(new DeleteFromCartCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new DeleteFromCartCommandResponse() { IsSuccess = false});
        }
    }
}
