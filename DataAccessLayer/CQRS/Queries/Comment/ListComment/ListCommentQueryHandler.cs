using DataAccessLayer.Abstract;
using MediatR;
using Serilog;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListCommentQueryHandler : IRequestHandler<ListCommentQueryRequest, ListCommentQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListCommentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ListCommentQueryResponse> Handle(ListCommentQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var comments = _unitOfWork.Comments.GetAll();
                return await Task.FromResult(new ListCommentQueryResponse() { Comments = comments, IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return await Task.FromResult(new ListCommentQueryResponse() { IsSuccess = false });
        }
    }
}
