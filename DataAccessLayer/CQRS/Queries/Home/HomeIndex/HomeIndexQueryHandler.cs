using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
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

        public async Task<HomeIndexQueryResponse> Handle(HomeIndexQueryRequest request, CancellationToken cancellationToken)
        {
            List<Product> products = new List<Product>();
            try
            {
                products = _unitOfWork.Products.GetHomePageProducts();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return new HomeIndexQueryResponse() 
            {
                Products = products,
                IsSuccess = true
            };
        }
    }
}
