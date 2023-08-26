using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditCommentQueryRequest: IRequest<EditCommentQueryResponse>
    {
        public double CommentId { get; set; }
    }
}