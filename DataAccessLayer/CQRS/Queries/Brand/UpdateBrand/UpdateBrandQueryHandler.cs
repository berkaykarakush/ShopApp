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

        public async Task<UpdateBrandQueryResponse> Handle(UpdateBrandQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var brand = _unitOfWork.Brands.GetById(request.BrandId);
                if (brand != null) 
                {
                    return new UpdateBrandQueryResponse() { Brand = brand ,IsSuccess = true };
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return new UpdateBrandQueryResponse() { IsSuccess = false };
        }
    }
}
