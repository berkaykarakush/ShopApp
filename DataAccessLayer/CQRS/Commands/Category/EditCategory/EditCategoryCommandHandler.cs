using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommandRequest, EditCategoryCommandResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public EditCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EditCategoryCommandResponse> Handle(EditCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category entity = new Category();
            try
            {
                entity = _unitOfWork.Categories.GetById(request.CategoryId);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return new EditCategoryCommandResponse() { IsSuccess = false };
            }
            entity.CategoryId = request.CategoryId;
            entity.Name = request.Name;
            entity.Url = request.Url;

            _unitOfWork.Categories.Update(entity);
            _unitOfWork.Save();

            return new EditCategoryCommandResponse()
            {
                IsSuccess = true
            };
        }
    }
}
