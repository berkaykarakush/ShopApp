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

        public Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var brand = _unitOfWork.Brands.GetById(request.BrandId);
                if (brand == null)
                    return Task.FromResult(new UpdateBrandCommandResponse() { IsSuccess = false});

                brand.Products = request.Products;
                brand.Name = request.Name;
                brand.Url = request.Url;
                brand.UpdatedDate = DateTime.Now;

                _unitOfWork.Brands.Update(brand);
                _unitOfWork.Save();

                return Task.FromResult(new UpdateBrandCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex) 
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new UpdateBrandCommandResponse() { IsSuccess = false });
        }
    }
}
