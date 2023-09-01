using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopBrandListQueryHandler : IRequestHandler<ShopBrandListQueryRequest, ShopBrandListQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopBrandListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ShopBrandListQueryResponse> Handle(ShopBrandListQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                const int pageSize = 15;
                var products = _unitOfWork.Products.GetProductByBrand(request.Brand, request.Page, pageSize);
                var totalItems = _unitOfWork.Products.GetCountByBrand(request.Brand);

                if (products == null || totalItems < 0)
                    return Task.FromResult(new ShopBrandListQueryResponse() { IsSuccess = false });

                return Task.FromResult(new ShopBrandListQueryResponse()
                {
                    IsSuccess = true,
                    Products = products,
                    PageInfo = new PageInfo()
                    {
                         CurrentCategory = request.Brand,
                         CurrentPage = request.Page,
                         TotalItems = totalItems,
                         ItemsPerPage = pageSize
                    }
                });

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new ShopBrandListQueryResponse() { IsSuccess = false });
        }
    }
}
