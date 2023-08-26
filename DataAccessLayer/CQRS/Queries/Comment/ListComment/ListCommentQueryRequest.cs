using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListCommentQueryRequest: IRequest<ListCommentQueryResponse>
    {
    }
}