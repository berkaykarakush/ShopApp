using DataAccessLayer.Abstract;
using MediatR;
using Serilog;
using System.Security.Cryptography.X509Certificates;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditStoreQueryHandler : IRequestHandler<EditStoreQueryRequest, EditStoreQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditStoreQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<EditStoreQueryResponse> Handle(EditStoreQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var store = _unitOfWork.Stores.GetByIdWithImageUrls(request.StoreId);
                
                if (store == null)
                    return Task.FromResult(new EditStoreQueryResponse() { IsSuccess = false });

                return Task.FromResult(new EditStoreQueryResponse() 
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
            return Task.FromResult(new EditStoreQueryResponse() { IsSuccess = false });
        }
    }
}
