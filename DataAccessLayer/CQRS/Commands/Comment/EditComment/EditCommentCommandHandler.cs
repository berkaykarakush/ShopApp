using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditCommentCommandHandler : IRequestHandler<EditCommentCommandRequest, EditCommentCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EditCommentCommandResponse> Handle(EditCommentCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _unitOfWork.Comments.GetById(request.CommentId);
                entity.Description = request.Description;
                entity.UpdatedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                _unitOfWork.Comments.Update(entity);
                _unitOfWork.Save();
                return await Task.FromResult(new EditCommentCommandResponse() { IsSuccess = true});
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return await Task.FromResult(new EditCommentCommandResponse() { IsSuccess = false });
        }
    }
}
