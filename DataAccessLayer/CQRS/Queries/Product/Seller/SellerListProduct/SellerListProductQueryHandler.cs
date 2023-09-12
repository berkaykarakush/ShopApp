using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerListProductQueryHandler : IRequestHandler<SellerListProductQueryRequest, SellerListProductQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerListProductQueryHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;
        
        public Task<SellerListProductQueryResponse> Handle(SellerListProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var store = _unitOfWork.Stores.GetStore(request.SellerId ?? string.Empty);

                if (store == null)
                    return Task.FromResult(new SellerListProductQueryResponse() { IsSucces = false });

                var allProducts = _unitOfWork.Products.GetStoreAllProducts(store.StoreId);

                if (allProducts == null)
                    return Task.FromResult(new SellerListProductQueryResponse() { IsSucces = false });

                return Task.FromResult(new SellerListProductQueryResponse() { IsSucces = true, Products = allProducts });

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerListProductQueryResponse() { IsSucces = false });
        }
    }
}
