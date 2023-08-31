using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditCategory2CommandHandler : IRequestHandler<EditCategory2CommandRequest, EditCategory2CommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditCategory2CommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<EditCategory2CommandResponse> Handle(EditCategory2CommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var category2 = _unitOfWork.Categories2.GetById(request.Category2Id);
                var category = _unitOfWork.Categories.GetById(request.CategoryId);

                if (category2 == null || category == null)
                    return Task.FromResult(new EditCategory2CommandResponse() { IsSuccess = false });

                category2.Name = request.Name;
                category2.Url = request.Url;
                category2.UpdatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                category2.Category2Id = request.Category2Id;
                category2.Category = category;
                _unitOfWork.Categories2.Update(category2);
                _unitOfWork.Save();

                return Task.FromResult(new EditCategory2CommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new EditCategory2CommandResponse() { IsSuccess = false });
        }
    }
}
