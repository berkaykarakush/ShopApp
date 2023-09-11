using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands 
{
    public class AdminEditStoreCommandHandler : IRequestHandler<AdminEditStoreCommandRequest, AdminEditStoreCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminEditStoreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminEditStoreCommandResponse> Handle(AdminEditStoreCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var store = _unitOfWork.Stores.GetByIdWithImageUrls(request.StoreId);

                if (store == null)
                    return Task.FromResult(new AdminEditStoreCommandResponse() { IsSuccess = false });

                store.StoreName = request.StoreName;
                store.StoreImage = request.StoreImage;
                store.StoreUrl = request.StoreUrl;

                if (store.ImageUrls != null)
                    store.ImageUrls.Clear();

                store.ImageUrls = request.ImageUrls;

                store.UpdatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                store.IsApproved = request.IsApproved;

                store.SellerFirstName = request.SellerFirstName;
                store.SellerLastName = request.SellerLastName;
                store.SellerEmail = request.SellerEmail;
                store.SellerPhone = request.SellerPhone;

                _unitOfWork.Stores.Update(store);
                _unitOfWork.Save();
                return Task.FromResult(new AdminEditStoreCommandResponse() { IsSuccess = true, StoreId = store.StoreId });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new AdminEditStoreCommandResponse() { IsSuccess = false });
        }
    }
}
