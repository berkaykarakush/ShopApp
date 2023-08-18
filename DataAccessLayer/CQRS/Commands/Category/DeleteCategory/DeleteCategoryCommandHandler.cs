using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;

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
            try
            {
                entity = _unitOfWork.Categories.GetById(request.categoryId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new DeleteCategoryCommandResponse() { IsSuccess = false};
            }

            string name = entity.Name;

            _unitOfWork.Categories.Delete(entity);
            _unitOfWork.Save();

            return new DeleteCategoryCommandResponse()
            {
                Name = name,
                IsSuccess = true
            };
        }
    }
}
