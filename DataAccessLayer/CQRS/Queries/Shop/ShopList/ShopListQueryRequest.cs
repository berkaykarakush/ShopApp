using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopListQueryRequest: IRequest<ShopListQueryResponse>
    {
        public ShopListQueryRequest()
        {
            page = 1;
        }
        public string category { get; set; }
        public int page { get; set; }
    }
}