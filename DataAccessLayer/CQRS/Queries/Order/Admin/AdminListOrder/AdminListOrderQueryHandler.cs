using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminListOrderQueryHandler : IRequestHandler<AdminListOrderQueryRequest, AdminListOrderQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminListOrderQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminListOrderQueryResponse> Handle(AdminListOrderQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var orders = _unitOfWork.Orders.GetAll();

                if (orders == null)
                    return Task.FromResult(new AdminListOrderQueryResponse() { IsSuccess = false });

                return Task.FromResult(new AdminListOrderQueryResponse() { IsSuccess = true, Orders = orders });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new AdminListOrderQueryResponse() { IsSuccess = false });
        }
    }
}
