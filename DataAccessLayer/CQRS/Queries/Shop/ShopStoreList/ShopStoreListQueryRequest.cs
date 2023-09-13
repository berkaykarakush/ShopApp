using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopStoreListQueryRequest: IRequest<ShopStoreListQueryResponse>
    {
        public int Page { get; set; } = 1;
        public string Store { get; set; }
    }
}