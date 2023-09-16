using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerDetailOrderCommandHandler : IRequestHandler<SellerDetailOrderCommandRequest, SellerDetailOrderCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerDetailOrderCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public Task<SellerDetailOrderCommandResponse> Handle(SellerDetailOrderCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var order = _unitOfWork.Orders.GetById(request.Id);

                if (order == null)
                    return Task.FromResult(new SellerDetailOrderCommandResponse() { IsSuccess = false });

                order.OrderState = request.OrderState;
                _unitOfWork.Orders.Update(order);
                _unitOfWork.Save();

                return Task.FromResult(new SellerDetailOrderCommandResponse() { IsSuccess = true, CustomerEmail = order.Email, OrderState = order.OrderState });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new SellerDetailOrderCommandResponse() { IsSuccess = false });
        }
    }
}
