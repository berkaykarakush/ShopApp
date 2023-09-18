using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerListCommentQueryRequest: IRequest<SellerListCommentQueryResponse>
    {
        public string UserId { get; set; }
    }
}