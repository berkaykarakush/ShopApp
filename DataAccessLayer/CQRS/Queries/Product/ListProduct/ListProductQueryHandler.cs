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

        public async Task<ListProductQueryResponse> Handle(ListProductQueryRequest request, CancellationToken cancellationToken)
        {
            List<Product> allProducts = new List<Product>();
            try
            {
                allProducts = _unitOfWork.Products.GetAll();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message); 
            }
            return new ListProductQueryResponse
            {
                Products = allProducts,
                IsSuccess = true
            };
        }
    }
}
