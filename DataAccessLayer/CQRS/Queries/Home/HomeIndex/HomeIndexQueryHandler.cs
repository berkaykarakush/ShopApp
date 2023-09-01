using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class HomeIndexQueryHandler : IRequestHandler<HomeIndexQueryRequest, HomeIndexQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeIndexQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<HomeIndexQueryResponse> Handle(HomeIndexQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
               var products = _unitOfWork.Products.GetHomePageProducts();

                if (products == null)
                    return Task.FromResult(new HomeIndexQueryResponse() { IsSuccess = false});

                return Task.FromResult(new HomeIndexQueryResponse() { IsSuccess = true, Products = products});
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new HomeIndexQueryResponse() { IsSuccess = false} );
        }
    }
}
