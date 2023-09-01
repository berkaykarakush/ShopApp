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

        public Task<DeleteFromCategoryCommandResponse> Handle(DeleteFromCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.productId < 0 || request.categoryId < 0)
                    return Task.FromResult(new DeleteFromCategoryCommandResponse() { IsSuccess = false});

              _unitOfWork.Categories.DeleteFromCategory(request.productId, request.categoryId);
              _unitOfWork.Save();
              return Task.FromResult(new DeleteFromCategoryCommandResponse() { IsSuccess = true, categoryId = request.categoryId });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new DeleteFromCategoryCommandResponse() { IsSuccess = false });
        }
    }
}
