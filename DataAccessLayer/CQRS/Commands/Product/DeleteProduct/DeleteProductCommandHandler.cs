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

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            string name = string.Empty;
            try
            {
                var entity = _unitOfWork.Products.GetById(request.productId);
                name = entity.Name;
                _unitOfWork.Products.Delete(entity);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
            
            return new DeleteProductCommandResponse()
            {
                Name = name,
                IsSuccess = true
            };
        }
    }
}
