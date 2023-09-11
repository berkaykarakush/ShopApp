using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminEditStoreQueryHandler : IRequestHandler<AdminEditStoreQueryRequest, AdminEditStoreQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminEditStoreQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminEditStoreQueryResponse> Handle(AdminEditStoreQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var store = _unitOfWork.Stores.GetByIdWithImageUrls(request.StoreId);

                if (store == null)
                    return Task.FromResult(new AdminEditStoreQueryResponse() { IsSuccess = false });

                return Task.FromResult(new AdminEditStoreQueryResponse()
                {
                    IsSuccess = true,
                    StoreId = store.StoreId,
                    StoreName = store.StoreName,
                    StoreUrl = store.StoreUrl,
                    StoreImage = store.StoreImage,
                    CreatedDate = store.CreatedDate,
                    UpdatedDate = store.UpdatedDate,
                    SellerId = store.SellerId,
                    SellerFirstName = store.SellerFirstName,
                    SellerLastName = store.SellerLastName,
                    SellerEmail = store.SellerEmail,
                    SellerPhone = store.SellerPhone,
                    IsApproved = store.IsApproved,
                    ImageUrls = store.ImageUrls
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new AdminEditStoreQueryResponse() { IsSuccess = false });
        }
    }
}
