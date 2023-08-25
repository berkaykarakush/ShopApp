using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBrandCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var brand = _unitOfWork.Brands.GetById(request.BrandId);
                if (brand != null)
                {
                    brand.Products = request.Products;
                    brand.Name = request.Name;
                    brand.Url = request.Url;
                    brand.UpdatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                    _unitOfWork.Brands.Update(brand);
                    _unitOfWork.Save();

                    return new UpdateBrandCommandResponse() { IsSuccess = true };
                }
            }
            catch (Exception ex) 
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return new UpdateBrandCommandResponse() { IsSuccess = false};
        }
    }
}
