using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminListProductQueryHandler : IRequestHandler<AdminListProductQueryRequest, AdminListProductQueryResponse>
    {
        readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AdminListProductQueryHandler> _logger;

        public AdminListProductQueryHandler(IUnitOfWork unitOfWork, ILogger<AdminListProductQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public Task<AdminListProductQueryResponse> Handle(AdminListProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var allProducts = _unitOfWork.Products.GetAll();

                if (allProducts == null)
                    return Task.FromResult(new AdminListProductQueryResponse() { IsSuccess = false});

                return Task.FromResult(new AdminListProductQueryResponse() { IsSuccess = true, Products = allProducts }); ;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}"); 
            }
            return Task.FromResult(new AdminListProductQueryResponse() { IsSuccess = false});
        }
    }
}
