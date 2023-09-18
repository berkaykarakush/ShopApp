using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class AdminListCommentQueryRequest: IRequest<AdminListCommentQueryResponse>
    {
    }
}