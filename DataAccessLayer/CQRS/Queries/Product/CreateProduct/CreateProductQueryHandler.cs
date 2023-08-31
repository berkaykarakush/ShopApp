using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class CreateProductQueryHandler : IRequestHandler<CreateProductQueryRequest, CreateProductQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<CreateProductQueryResponse> Handle(CreateProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = _unitOfWork.Categories.GetAll();
                var categories2 = _unitOfWork.Categories2.GetAll();
                var brands = _unitOfWork.Brands.GetAll();
                if (categories == null && brands == null)
                    return Task.FromResult(new CreateProductQueryResponse() { IsSuccess = false});

                return Task.FromResult(new CreateProductQueryResponse() { Categories = categories, Categories2 = categories2, Brands = brands, IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new CreateProductQueryResponse() { IsSuccess  = false});
        }
    }
}
