using Azure;
using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class TopSalesListQueryHandler : IRequestHandler<TopSalesListQueryRequest, TopSalesListQueryResponse>
    {
        private IUnitOfWork _unitOfWork;

        public TopSalesListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TopSalesListQueryResponse> Handle(TopSalesListQueryRequest request, CancellationToken cancellationToken)
        {
            const int pageSize = 15;
            List<Product> products = new List<Product>();
            int totalItems = 0;

            try
            {
                totalItems = _unitOfWork.Products.GetCountTopSalesProduct();
                products = _unitOfWork.Products.GetTopSalesProducts(request.page, pageSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new TopSalesListQueryResponse() { IsSuccess = false };
            }

            return new TopSalesListQueryResponse()
            {
                PageInfo = new PageInfo()
                {
                    CurrentPage = request.page,
                    ItemsPerPage = pageSize,
                    TotalItems = totalItems
                },
                Products = products,
                IsSuccess = true    
            };
        }
    }
}
