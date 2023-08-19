using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopSearchQueryRequest:IRequest<ShopSearchQueryResponse>
    {
        public string q { get; set; }
    }
}