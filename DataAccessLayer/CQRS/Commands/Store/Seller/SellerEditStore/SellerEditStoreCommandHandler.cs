using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using Serilog;
using System.Data;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerEditStoreCommandHandler : IRequestHandler<SellerEditStoreCommandRequest, SellerEditStoreCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerEditStoreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<SellerEditStoreCommandResponse> Handle(SellerEditStoreCommandRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var store = _unitOfWork.Stores.GetByIdWithImageUrls(request.StoreId);

                if (store == null)
                    return Task.FromResult(new SellerEditStoreCommandResponse() { IsSuccess = false });

                store.StoreId = request.StoreId;
                store.StoreName = request.StoreName;
                store.UpdatedDate = DateTime.Now;
                store.StoreImage = request.StoreImage;
                store.SellerFirstName = request.SellerFirstName;
                store.SellerLastName = request.SellerLastName;
                store.SellerPhone = request.SellerPhone;
                store.SellerEmail = request.SellerEmail;
                store.IsApproved = request.IsApproved;
                store.StoreUrl = request.StoreUrl;

                if (store.ImageUrls != null)
                    store.ImageUrls.Clear();

                store.ImageUrls?.Add(new ImageUrl()
                {
                    CreatedDate = DateTime.Now,
                    Product = null,
                    ProductId = null,
                    Store = store,
                    StoreId = store.StoreId,
                    Url = request.StoreImage
                });

                _unitOfWork.Stores.Update(store);
                _unitOfWork.Save();
                return Task.FromResult(new SellerEditStoreCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerEditStoreCommandResponse() { IsSuccess = false });
        }
    }
}
