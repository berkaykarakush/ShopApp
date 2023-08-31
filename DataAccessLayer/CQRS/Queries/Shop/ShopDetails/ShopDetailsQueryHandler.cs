using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;
using System;
using System.Net.Http.Headers;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopDetailsQueryHandler : IRequestHandler<ShopDetailsQueryRequest, ShopDetailsQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopDetailsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ShopDetailsQueryResponse> Handle(ShopDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = _unitOfWork.Products.GetProductDetails(request.Url);

                if (product == null)
                    return Task.FromResult(new ShopDetailsQueryResponse() { IsSuccess = false });

                return Task.FromResult(new ShopDetailsQueryResponse() { IsSuccess = true, Product = product, Comments = product.Comments });

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new ShopDetailsQueryResponse() { IsSuccess = false });
        }
    }
}
