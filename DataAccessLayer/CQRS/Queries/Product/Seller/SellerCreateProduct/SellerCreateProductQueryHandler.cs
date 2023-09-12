using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerCreateProductQueryHandler : IRequestHandler<SellerCreateProductQueryRequest, SellerCreateProductQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerCreateProductQueryHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public Task<SellerCreateProductQueryResponse> Handle(SellerCreateProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var brands = _unitOfWork.Brands.GetAll();
                var categories = _unitOfWork.Categories.GetAll();
                var categories2 = _unitOfWork.Categories2.GetAll();

                if (brands == null || categories == null || categories2 == null)
                    return Task.FromResult(new SellerCreateProductQueryResponse() { IsSuccess = false });

                return Task.FromResult(new SellerCreateProductQueryResponse() { IsSuccess = true, Brands = brands, Categories = categories, Categories2 = categories2 });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerCreateProductQueryResponse() { IsSuccess = false });
        }
    }
}
