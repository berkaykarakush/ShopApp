using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopDetailsQueryRequest:IRequest<ShopDetailsQueryResponse>
    {
        public string Url { get; set; }
    }
}