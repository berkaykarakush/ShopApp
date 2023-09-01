using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _unitOfWork.Categories.GetById(request.categoryId);

                if (entity == null)
                    return Task.FromResult(new DeleteCategoryCommandResponse() { IsSuccess = false});

                _unitOfWork.Categories.Delete(entity);
                _unitOfWork.Save();
                return Task.FromResult(new DeleteCategoryCommandResponse() { Name = entity.Name, IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new DeleteCategoryCommandResponse() { IsSuccess = false});
        }
    }
}
