using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerAnswerCommentCommandHandler : IRequestHandler<SellerAnswerCommentCommandRequest, SellerAnswerCommentCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellerAnswerCommentCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public Task<SellerAnswerCommentCommandResponse> Handle(SellerAnswerCommentCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var comment = _unitOfWork.Comments.GetById(request.CommentId);

                if (comment == null)
                    return Task.FromResult(new SellerAnswerCommentCommandResponse() { IsSuccess = false });

                comment.SellerAnswer = request.SellerAnswer;

                _unitOfWork.Comments.Update(comment);
                _unitOfWork.Save();

                return Task.FromResult(new SellerAnswerCommentCommandResponse() { IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return Task.FromResult(new SellerAnswerCommentCommandResponse() { IsSuccess = false });
        }
    }
}
