using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminEditCommentQueryRequest: IRequest<AdminEditCommentQueryResponse>
    {
        public double CommentId { get; set; }
    }
}