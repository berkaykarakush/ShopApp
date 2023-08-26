using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditCommentQueryHandler : IRequestHandler<EditCommentQueryRequest, EditCommentQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditCommentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EditCommentQueryResponse> Handle(EditCommentQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _unitOfWork.Comments.GetById(request.CommentId);
                return await Task.FromResult(new EditCommentQueryResponse()
                {
                    CommentId = entity.CommentId,
                    CreatedDate = entity.CreatedDate,
                    Description = entity.Description,
                    Product = entity.Product,
                    ProductId = entity.ProductId,
                    UpdatedDate = entity.UpdatedDate,
                    UserId = entity.UserId,
                    IsSuccess = true
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }
            return await Task.FromResult(new EditCommentQueryResponse() { IsSuccess = false });
        }
    }
}
