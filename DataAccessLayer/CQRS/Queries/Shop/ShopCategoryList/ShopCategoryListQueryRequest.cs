using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopCategoryListQueryRequest: IRequest<ShopCategoryListQueryResponse>
    {
        public string? category { get; set; }
        public int page { get; set; } = 1;
    }
}