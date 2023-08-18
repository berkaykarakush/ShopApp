using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteFromCategoryCommandHandler : IRequestHandler<DeleteFromCategoryCommandRequest, DeleteFromCategoryCommandResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public DeleteFromCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteFromCategoryCommandResponse> Handle(DeleteFromCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
              _unitOfWork.Categories.DeleteFromCategory(request.productId, request.categoryId);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return new DeleteFromCategoryCommandResponse() {IsSuccess = false };
            }

            _unitOfWork.Save();
            return new DeleteFromCategoryCommandResponse() 
            {
                categoryId = request.categoryId,
                IsSuccess = true
            };
        }
    }
}
