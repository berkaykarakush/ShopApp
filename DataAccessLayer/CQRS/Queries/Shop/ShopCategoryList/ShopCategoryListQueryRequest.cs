using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopCategoryListQueryRequest: IRequest<ShopCategoryListQueryResponse>
    {
        public ShopCategoryListQueryRequest()
        {
            page = 1;
        }
        public string category { get; set; }
        public int page { get; set; }
    }
}