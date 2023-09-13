using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class ShopStoreListQueryResponse
    {
        public List<Product>? Products { get; set; }
        public bool IsSuccess { get; set; }
        public PageInfo? PageInfo { get; set; }
        public string? StoreName { get; set; }
        public string? StoreUrl { get; set; }
        public string? StoreImage { get; set; }
    }
}