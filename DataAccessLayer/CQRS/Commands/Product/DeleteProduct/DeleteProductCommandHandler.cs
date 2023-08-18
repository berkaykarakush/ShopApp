using DataAccessLayer.Abstract;
using MediatR;

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
            var entity = _unitOfWork.Products.GetById(request.productId);
            var name = entity.Name;

            _unitOfWork.Products.Delete(entity);
            _unitOfWork.Save();

            return new DeleteProductCommandResponse()
            {
                Name = name,
                IsSuccess = true
            };
        }
    }
}
