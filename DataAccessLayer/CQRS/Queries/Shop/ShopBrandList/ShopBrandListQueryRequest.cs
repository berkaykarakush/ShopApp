using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopBrandListQueryRequest: IRequest<ShopBrandListQueryResponse>
    {
        public int Page { get; set; } = 1;
        public string Brand { get; set; }
    }
}