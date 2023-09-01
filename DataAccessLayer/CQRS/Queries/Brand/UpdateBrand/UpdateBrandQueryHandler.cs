using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class UpdateBrandQueryHandler : IRequestHandler<UpdateBrandQueryRequest, UpdateBrandQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBrandQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<UpdateBrandQueryResponse> Handle(UpdateBrandQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var brand = _unitOfWork.Brands.GetById(request.BrandId);

                if (brand == null)
                    return Task.FromResult(new UpdateBrandQueryResponse() { IsSuccess = false});

                return Task.FromResult(new UpdateBrandQueryResponse() { Brand = brand, IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new UpdateBrandQueryResponse() { IsSuccess = false });
        }
    }
}
