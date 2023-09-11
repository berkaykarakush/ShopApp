using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerStoreIndexQueryHandler : IRequestHandler<SellerStoreIndexQueryRequest, SellerStoreIndexQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerStoreIndexQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<SellerStoreIndexQueryResponse> Handle(SellerStoreIndexQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var store = _unitOfWork.Stores.GetByUserIdWithImageUrls(request.UserId);

                if (store == null)
                    return Task.FromResult(new SellerStoreIndexQueryResponse() { IsSuccess = false });

                return Task.FromResult(new SellerStoreIndexQueryResponse()
                { 
                    IsSuccess = true,
                    CreatedDate = store.CreatedDate,
                    ImageUrls = store.ImageUrls,
                    IsApproved = store.IsApproved,
                    SellerEmail = store.SellerEmail,
                    SellerFirstName = store.SellerFirstName,
                    SellerId = store.SellerId,
                    SellerLastName = store.SellerLastName,
                    SellerPhone = store.SellerPhone,
                    StoreId = store.StoreId,
                    StoreName = store.StoreName,
                    StoreImage = store.StoreImage,
                    StoreUrl = store.StoreUrl,
                    UpdatedDate = store.UpdatedDate
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerStoreIndexQueryResponse() { IsSuccess = false });
        }
    }
}
