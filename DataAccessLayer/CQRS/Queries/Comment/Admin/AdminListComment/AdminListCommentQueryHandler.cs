using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminListCommentQueryHandler : IRequestHandler<AdminListCommentQueryRequest, AdminListCommentQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminListCommentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AdminListCommentQueryResponse> Handle(AdminListCommentQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var comments = _unitOfWork.Comments.GetAll();

                if (comments == null)
                    return Task.FromResult(new AdminListCommentQueryResponse() { IsSuccess = false});

                return Task.FromResult(new AdminListCommentQueryResponse() { Comments = comments, IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new AdminListCommentQueryResponse() { IsSuccess = false });
        }
    }
}
