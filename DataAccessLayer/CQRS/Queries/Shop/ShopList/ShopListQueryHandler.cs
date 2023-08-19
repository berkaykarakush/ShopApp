using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopListQueryHandler : IRequestHandler<ShopListQueryRequest, ShopListQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShopListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShopListQueryResponse> Handle(ShopListQueryRequest request, CancellationToken cancellationToken)
        {
            const int pageSize = 15;
            List<Product> products = new List<Product>();
            int totalItems = 0;
            try
            {
                products = _unitOfWork.Products.GetProductsByCategory(request.category, request.page, pageSize);
                totalItems = _unitOfWork.Products.GetCountByCategory(request.category);
            }
            catch (Exception)
            {

                return new ShopListQueryResponse() { IsSuccess = false };
            }

            return new ShopListQueryResponse()
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
