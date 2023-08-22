using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

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
              _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return new DeleteFromCategoryCommandResponse() 
            {
                categoryId = request.categoryId,
                IsSuccess = true
            };
        }
    }
}
