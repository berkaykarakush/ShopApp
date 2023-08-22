using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;
using System.Net.Http.Headers;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopSearchQueryHandler : IRequestHandler<ShopSearchQueryRequest, ShopSearchQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopSearchQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShopSearchQueryResponse> Handle(ShopSearchQueryRequest request, CancellationToken cancellationToken)
        {
            List<Product> products = new List<Product>();
            try
            {
                products = _unitOfWork.Products.GetSearchResult(request.q);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return new ShopSearchQueryResponse() 
            {
                Products = products,
                IsSuccess = true
            };
        }
    }
}
