using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteCategory2CommandHandler : IRequestHandler<DeleteCategory2CommandRequest, DeleteCategory2CommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategory2CommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<DeleteCategory2CommandResponse> Handle(DeleteCategory2CommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var category2 = _unitOfWork.Categories2.GetById(request.Category2Id);

                if (category2 == null)
                    return Task.FromResult(new DeleteCategory2CommandResponse() { IsSuccess = false });

                _unitOfWork.Categories2.Delete(category2);
                _unitOfWork.Save();
                return Task.FromResult(new DeleteCategory2CommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
                throw;
            }
            return Task.FromResult(new DeleteCategory2CommandResponse() { IsSuccess = false });
        }
    }
}
