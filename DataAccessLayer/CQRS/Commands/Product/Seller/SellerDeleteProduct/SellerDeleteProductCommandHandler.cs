using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerDeleteProductCommandHandler : IRequestHandler<SellerDeleteProductCommandRequest, SellerDeleteProductCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerDeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<SellerDeleteProductCommandResponse> Handle(SellerDeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _unitOfWork.Products.GetById(request.ProductId);

                if (product == null)
                    return Task.FromResult(new SellerDeleteProductCommandResponse() { IsSuccess = false });

                _unitOfWork.Products.Delete(product);
                _unitOfWork.Save();
                return Task.FromResult(new SellerDeleteProductCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Messsage: {ex.Message}");
            }
            return Task.FromResult(new SellerDeleteProductCommandResponse() {IsSuccess = false });
        }
    }
}
