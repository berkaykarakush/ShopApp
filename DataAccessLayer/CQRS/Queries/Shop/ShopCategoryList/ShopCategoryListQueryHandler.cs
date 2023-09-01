using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopCategoryListQueryHandler : IRequestHandler<ShopCategoryListQueryRequest, ShopCategoryListQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShopCategoryListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ShopCategoryListQueryResponse> Handle(ShopCategoryListQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                const int pageSize = 15;
                var products = _unitOfWork.Products.GetProductsByCategory(request.category, request.page, pageSize);
                var totalItems = _unitOfWork.Products.GetCountByCategory(request.category);

                if (products == null || totalItems < 0)
                    return Task.FromResult(new ShopCategoryListQueryResponse() { IsSuccess = false });

                return Task.FromResult(new ShopCategoryListQueryResponse() 
                {
                    IsSuccess = true,
                    PageInfo = new PageInfo() 
                    {
                        ItemsPerPage = pageSize,
                        TotalItems = totalItems,
                        CurrentCategory = request.category,
                        CurrentPage = request.page
                    },
                    Products = products
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new ShopCategoryListQueryResponse() { IsSuccess = false });
        }
    }
}
