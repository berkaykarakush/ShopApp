using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListProductQueryHandler : IRequestHandler<ListProductQueryRequest, ListProductQueryResponse>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListProductQueryHandler> _logger;

        public ListProductQueryHandler(IUnitOfWork unitOfWork, ILogger<ListProductQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public Task<ListProductQueryResponse> Handle(ListProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var allProducts = _unitOfWork.Products.GetAll();

                if (allProducts == null)
                    return Task.FromResult(new ListProductQueryResponse() { IsSuccess = false});

                return Task.FromResult(new ListProductQueryResponse() { IsSuccess = true, Products = allProducts }); ;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}"); 
            }
            return Task.FromResult(new ListProductQueryResponse() { IsSuccess = false});
        }
    }
}
