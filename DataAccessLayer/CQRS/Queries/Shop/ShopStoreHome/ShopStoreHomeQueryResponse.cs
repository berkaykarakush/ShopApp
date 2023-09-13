namespace DataAccessLayer.CQRS.Queries
{
    public class ShopStoreHomeQueryResponse
    {
        public bool IsSuccess { get; set; }
        public string? StoreName { get; set; }
        public string? StoreUrl { get; set; }
        public string? StoreImage { get; set; }
    }
}