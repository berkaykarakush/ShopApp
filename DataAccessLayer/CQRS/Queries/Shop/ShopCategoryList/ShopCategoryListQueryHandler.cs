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

        public async Task<ShopCategoryListQueryResponse> Handle(ShopCategoryListQueryRequest request, CancellationToken cancellationToken)
        {
            const int pageSize = 15;
            List<Product> products = new List<Product>();
            int totalItems = 0;
            try
            {
                products = _unitOfWork.Products.GetProductsByCategory(request.category, request.page, pageSize);
                totalItems = _unitOfWork.Products.GetCountByCategory(request.category);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return new ShopCategoryListQueryResponse()
            {
                PageInfo = new PageInfo()
                {
                    CurrentPage = request.page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = request.category,
                    TotalItems = totalItems
                },
                Products = products,
                IsSuccess = true
            };

            //return _mapper.Map<ShopListQueryResponse>(response);
        }
    }
}
