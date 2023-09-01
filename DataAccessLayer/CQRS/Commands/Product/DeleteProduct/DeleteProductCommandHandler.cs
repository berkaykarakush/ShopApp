using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;
using System.Net.Http.Headers;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _unitOfWork.Products.GetById(request.productId);
                if (entity == null)
                    return Task.FromResult(new DeleteProductCommandResponse() { IsSuccess = false });

                _unitOfWork.Products.Delete(entity);
                _unitOfWork.Save();
                return Task.FromResult(new DeleteProductCommandResponse() { IsSuccess = true, Name = entity.Name});
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new DeleteProductCommandResponse() { IsSuccess = false});
        }
    }
}
