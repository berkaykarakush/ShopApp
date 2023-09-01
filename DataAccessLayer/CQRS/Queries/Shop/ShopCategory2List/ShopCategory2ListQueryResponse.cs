using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopCategory2ListQueryResponse
    {
        public bool IsSuccess { get; set; }
        public PageInfo? PageInfo { get; set; }
        public List<Product>? Products { get; set; } = new List<Product>();
    }
}