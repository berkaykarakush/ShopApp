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

        public Task<ListCommentQueryResponse> Handle(ListCommentQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var comments = _unitOfWork.Comments.GetAll();

                if (comments == null)
                    return Task.FromResult(new ListCommentQueryResponse() { IsSuccess = false});

                return Task.FromResult(new ListCommentQueryResponse() { Comments = comments, IsSuccess = true });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Source: {ex.Source} - Message: {ex.Message}");
            }

            return Task.FromResult(new ListCommentQueryResponse() { IsSuccess = false });
        }
    }
}
