using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerDetailOrderQueryHandler : IRequestHandler<SellerDetailOrderQueryRequest, SellerDetailOrderQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerDetailOrderQueryHandler(IUnitOfWork unitOfWork)
           => _unitOfWork = unitOfWork;

        public Task<SellerDetailOrderQueryResponse> Handle(SellerDetailOrderQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var order = _unitOfWork.Orders.GetByOrderWithOrderItems(request.Id);

                if (order == null)
                    return Task.FromResult(new SellerDetailOrderQueryResponse() { IsSuccess = false });

                return Task.FromResult(new SellerDetailOrderQueryResponse() { IsSuccess = true, Order = order });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new SellerDetailOrderQueryResponse() { IsSuccess = false });
        }
    }
}
