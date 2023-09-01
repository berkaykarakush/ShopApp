using Azure;
using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;
using System.Runtime.InteropServices;

namespace DataAccessLayer.CQRS.Queries
{
    public class TopSalesListQueryHandler : IRequestHandler<TopSalesListQueryRequest, TopSalesListQueryResponse>
    {
        private IUnitOfWork _unitOfWork;

        public TopSalesListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<TopSalesListQueryResponse> Handle(TopSalesListQueryRequest request, CancellationToken cancellationToken)
        {
            const int pageSize = 15;

            try
            {
                var totalItems = _unitOfWork.Products.GetCountTopSalesProduct();
                var products = _unitOfWork.Products.GetTopSalesProducts(request.page, pageSize);

                if (products == null || totalItems < 0)
                    return Task.FromResult(new TopSalesListQueryResponse() { IsSuccess = false});

                return Task.FromResult(new TopSalesListQueryResponse() 
                {
                    PageInfo = new PageInfo()
                    {
                        CurrentPage = request.page,
                        ItemsPerPage = pageSize,
                        TotalItems = totalItems
                    },
                    Products = products,
                    IsSuccess = true    
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new TopSalesListQueryResponse() { IsSuccess = false});
        }
    }
}
