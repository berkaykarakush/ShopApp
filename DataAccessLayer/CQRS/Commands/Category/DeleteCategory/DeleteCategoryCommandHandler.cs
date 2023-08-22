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

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category entity = new Category();
            string name = string.Empty;
            try
            {
                entity = _unitOfWork.Categories.GetById(request.categoryId);
                name = entity.Name;

                _unitOfWork.Categories.Delete(entity);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return new DeleteCategoryCommandResponse()
            {
                Name = name,
                IsSuccess = true
            };
        }
    }
}
