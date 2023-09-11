using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands 
{
    public class AdminDeleteOrderCommandHandler : IRequestHandler<AdminDeleteOrderCommandRequest, AdminDeleteOrderCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminDeleteOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminDeleteOrderCommandResponse> Handle(AdminDeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var order = _unitOfWork.Orders.GetById(request.OrderId);

                if (order == null)
                    return Task.FromResult(new AdminDeleteOrderCommandResponse() { IsSuccess = false });

                _unitOfWork.Orders.Delete(order);
                _unitOfWork.Save();
                return Task.FromResult(new AdminDeleteOrderCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new AdminDeleteOrderCommandResponse() { IsSuccess = false });
        }
    }
}
