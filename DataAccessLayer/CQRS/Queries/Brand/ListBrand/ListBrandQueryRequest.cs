using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class ListBrandQueryRequest: IRequest<ListBrandQueryResponse>
    {
    }
}