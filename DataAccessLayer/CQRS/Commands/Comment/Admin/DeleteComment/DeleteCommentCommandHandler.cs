using DataAccessLayer.Abstract;
using MediatR;
using Serilog;
using System.Runtime.CompilerServices;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommandRequest, DeleteCommentCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  Task<DeleteCommentCommandResponse> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _unitOfWork.Comments.GetById(request.CommentId);

                if (entity == null)
                    return Task.FromResult(new DeleteCommentCommandResponse() { IsSuccess = false });

                _unitOfWork.Comments.Delete(entity);
                _unitOfWork.Save();
                return Task.FromResult(new DeleteCommentCommandResponse() { IsSuccess = true});
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new DeleteCommentCommandResponse() { IsSuccess = false });
        }
    }
}
