using DataAccessLayer.Abstract;
using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListProductQueryHandler : IRequestHandler<ListProductQueryRequest, ListProductQueryResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public ListProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ListProductQueryResponse> Handle(ListProductQueryRequest request, CancellationToken cancellationToken)
        {
            var allProducts = _unitOfWork.Products.GetAll();

            return new ListProductQueryResponse
            {
                Products = allProducts,
                Success = true
            };
        }
    }
}
