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
            try
            {
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
