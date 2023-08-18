using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListCategoryQueryRequest :IRequest<ListCategoryQueryResponse>
    {
    }
}