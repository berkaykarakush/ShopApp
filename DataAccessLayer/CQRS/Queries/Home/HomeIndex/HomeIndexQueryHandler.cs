using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;

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
                Console.WriteLine(ex.Message);
                return new HomeIndexQueryResponse() { IsSuccess = false };
            }

            return new HomeIndexQueryResponse() 
            {
                Products = products,
                IsSuccess = true
            };
        }
    }
}
