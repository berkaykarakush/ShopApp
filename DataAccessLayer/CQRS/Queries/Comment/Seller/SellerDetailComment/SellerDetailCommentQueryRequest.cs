using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerDetailCommentQueryRequest: IRequest<SellerDetailCommentQueryResponse>
    {
        public double CommentId { get; set; }
    }
}