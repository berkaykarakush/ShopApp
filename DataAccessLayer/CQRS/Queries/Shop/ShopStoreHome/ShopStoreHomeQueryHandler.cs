using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopStoreHomeQueryHandler : IRequestHandler<ShopStoreHomeQueryRequest, ShopStoreHomeQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopStoreHomeQueryHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public Task<ShopStoreHomeQueryResponse> Handle(ShopStoreHomeQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var store = _unitOfWork.Stores.GetStoreByStoreUrl(request.Store);

                if (store == null)
                    return Task.FromResult(new ShopStoreHomeQueryResponse() { IsSuccess = false });

                return Task.FromResult(new ShopStoreHomeQueryResponse()
                { 
                    IsSuccess = true,
                    StoreImage = store.StoreImage,
                    StoreName = store.StoreName,
                    StoreUrl = store.StoreUrl
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new ShopStoreHomeQueryResponse() { IsSuccess = false });
        }
    }
}
