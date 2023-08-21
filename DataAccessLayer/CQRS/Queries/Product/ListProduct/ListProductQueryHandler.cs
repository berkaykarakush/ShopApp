using DataAccessLayer.Abstract;
using MediatR;
using Microsoft.Extensions.Logging;

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
            try
            {
                _logger.LogInformation("LIST PRODUCT");
                var allProducts = _unitOfWork.Products.GetAll();

                return new ListProductQueryResponse
                {
                    Products = allProducts,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return new ListProductQueryResponse() { IsSuccess = false };    
            }
        }
    }
}
