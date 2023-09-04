using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListStoreQueryHandler : IRequestHandler<ListStoreQueryRequest, ListStoreQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListStoreQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ListStoreQueryResponse> Handle(ListStoreQueryRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var stores = _unitOfWork.Stores.GetAll();

                if (stores == null)
                    return Task.FromResult(new ListStoreQueryResponse() { IsSuccess = false });

                return Task.FromResult(new ListStoreQueryResponse() { IsSuccess = true, Stores = stores });

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new ListStoreQueryResponse() { IsSuccess = false});
        }
    }
}
