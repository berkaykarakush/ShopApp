using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminEditCommentQueryHandler : IRequestHandler<AdminEditCommentQueryRequest, AdminEditCommentQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminEditCommentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminEditCommentQueryResponse> Handle(AdminEditCommentQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _unitOfWork.Comments.GetById(request.CommentId);

                if (entity == null)
                    return Task.FromResult(new AdminEditCommentQueryResponse() { IsSuccess = false});

                return Task.FromResult(new AdminEditCommentQueryResponse()
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
            return Task.FromResult(new AdminEditCommentQueryResponse() { IsSuccess = false });
        }
    }
}
