using MediatR;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopCategory2ListQueryRequest: IRequest<ShopCategory2ListQueryResponse>
    {
        public string? Category2 { get; set; }
        public int Page { get; set; } = 1;
    }
}