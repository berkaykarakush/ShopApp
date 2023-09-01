using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
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

        public Task<ShopSearchQueryResponse> Handle(ShopSearchQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var products = _unitOfWork.Products.GetSearchResult(request.q);

                if (products == null)
                    return Task.FromResult(new ShopSearchQueryResponse() { IsSuccess = false });

                return Task.FromResult(new ShopSearchQueryResponse() { IsSuccess = true, Products = products});
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new ShopSearchQueryResponse() { IsSuccess = false});
        }
    }
}
