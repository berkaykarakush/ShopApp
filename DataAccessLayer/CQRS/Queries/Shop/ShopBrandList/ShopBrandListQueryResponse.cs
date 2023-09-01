using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopBrandListQueryResponse
    {
        public bool IsSuccess { get; set; }
        public PageInfo? PageInfo { get; set; }
        public List<Product>? Products { get; set; }
    }
}
