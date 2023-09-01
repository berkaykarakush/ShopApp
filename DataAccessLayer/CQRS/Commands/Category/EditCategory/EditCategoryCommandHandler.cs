using DataAccessLayer.Abstract;
using EntityLayer;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommandRequest, EditCategoryCommandResponse>
    {
        readonly IUnitOfWork _unitOfWork;

        public EditCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<EditCategoryCommandResponse> Handle(EditCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _unitOfWork.Categories.GetById(request.CategoryId);
                if (entity == null)
                    return Task.FromResult(new EditCategoryCommandResponse() { IsSuccess = false });

                entity.CategoryId = request.CategoryId;
                entity.Name = request.Name;
                entity.Url = request.Url;

                _unitOfWork.Categories.Update(entity);
                _unitOfWork.Save();
                return Task.FromResult(new EditCategoryCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new EditCategoryCommandResponse() { IsSuccess = false });
        }
    }
}
