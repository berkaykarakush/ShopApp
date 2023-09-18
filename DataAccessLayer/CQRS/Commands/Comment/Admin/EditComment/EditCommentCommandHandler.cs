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

        public Task<EditCommentCommandResponse> Handle(EditCommentCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _unitOfWork.Comments.GetById(request.CommentId);

                if (entity == null)
                    return Task.FromResult(new EditCommentCommandResponse() { IsSuccess = false});

                entity.Description = request.Description;
                entity.UpdatedDate = DateTime.Now;
                _unitOfWork.Comments.Update(entity);
                _unitOfWork.Save();
                return  Task.FromResult(new EditCommentCommandResponse() { IsSuccess = true});
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return  Task.FromResult(new EditCommentCommandResponse() { IsSuccess = false });
        }
    }
}
