using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopCategory2ListQueryHandler : IRequestHandler<ShopCategory2ListQueryRequest, ShopCategory2ListQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopCategory2ListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ShopCategory2ListQueryResponse> Handle(ShopCategory2ListQueryRequest request, CancellationToken cancellationToken)
        {
            const int pageSize = 15;
            try
            {
                var products = _unitOfWork.Products.GetProductsByCategory2(request.Category2, request.Page, pageSize);
                var totalItems = _unitOfWork.Products.GetCountByCategory2(request.Category2);

                if (products == null || totalItems == null)
                    return Task.FromResult(new ShopCategory2ListQueryResponse() { IsSuccess = false });

                return Task.FromResult(new ShopCategory2ListQueryResponse() 
                {
                    IsSuccess = true,
                    Products = products,
                    PageInfo = new PageInfo()
                    {
                        CurrentCategory = request.Category2,
                        TotalItems = totalItems,
                        CurrentPage = request.Page,
                        ItemsPerPage = pageSize
                    }
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new ShopCategory2ListQueryResponse() { IsSuccess = false });
        }
    }
}
