using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommandRequest, DeleteBrandCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBrandCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<DeleteBrandCommandResponse> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var brand = _unitOfWork.Brands.GetById(request.BrandId);

                if (brand == null)
                    return Task.FromResult(new DeleteBrandCommandResponse() { IsSuccess = false});

                _unitOfWork.Brands.Delete(brand);
                _unitOfWork.Save();

                return Task.FromResult(new DeleteBrandCommandResponse() { IsSuccess = false });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new DeleteBrandCommandResponse() { IsSuccess = false });
        }
    }
}
