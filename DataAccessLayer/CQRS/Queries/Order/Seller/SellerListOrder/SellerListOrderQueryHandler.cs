using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerListOrderQueryHandler : IRequestHandler<SellerListOrderQueryRequest, SellerListOrderQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerListOrderQueryHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public Task<SellerListOrderQueryResponse> Handle(SellerListOrderQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var store = _unitOfWork.Stores.GetStore(request.UserId);

                var orders = store.Orders?.OrderByDescending(o => o.OrderDate).ToList();

                if (orders == null)
                    return Task.FromResult(new SellerListOrderQueryResponse() { IsSuccess = false });

                return Task.FromResult(new SellerListOrderQueryResponse() { IsSuccess = true, Orders = orders});
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerListOrderQueryResponse() { IsSuccess = false });
        }
    }
}
