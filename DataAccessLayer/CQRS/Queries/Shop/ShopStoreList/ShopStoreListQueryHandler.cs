using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopStoreListQueryHandler : IRequestHandler<ShopStoreListQueryRequest, ShopStoreListQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopStoreListQueryHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public Task<ShopStoreListQueryResponse> Handle(ShopStoreListQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                const int pageSize = 15;

                var allProducts = _unitOfWork.Products.GetStoreAllProducts(request.Store, request.Page, pageSize);
                var totalItems = _unitOfWork.Products.GetCountByStore(request.Store);
                var store = _unitOfWork.Stores.GetStoreByStoreUrl(request.Store);

                if (allProducts == null)
                    return Task.FromResult(new ShopStoreListQueryResponse() { IsSuccess = false });

                return Task.FromResult(new ShopStoreListQueryResponse() 
                { 
                    IsSuccess = true, 
                    Products = allProducts,
                    PageInfo = new PageInfo()
                    {
                        CurrentCategory = request.Store,
                        CurrentPage = request.Page,
                        TotalItems = totalItems,
                        ItemsPerPage = pageSize
                    },
                    StoreName = store.StoreName,
                    StoreImage = store.StoreImage,
                    StoreUrl = store.StoreUrl
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new ShopStoreListQueryResponse() { IsSuccess = false });
        }
    }
}
