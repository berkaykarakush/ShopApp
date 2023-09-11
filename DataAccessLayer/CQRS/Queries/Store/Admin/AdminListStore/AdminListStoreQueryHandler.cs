using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminListStoreQueryHandler : IRequestHandler<AdminListStoreQueryRequest, AdminListStoreQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminListStoreQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminListStoreQueryResponse> Handle(AdminListStoreQueryRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var stores = _unitOfWork.Stores.GetAll();

                if (stores == null)
                    return Task.FromResult(new AdminListStoreQueryResponse() { IsSuccess = false });

                return Task.FromResult(new AdminListStoreQueryResponse() { IsSuccess = true, Stores = stores });

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new AdminListStoreQueryResponse() { IsSuccess = false });
        }
    }
}
