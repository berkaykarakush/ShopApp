using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerStoreIndexQueryResponse
    {
        public bool IsSuccess { get; set; }
        public double StoreId { get; set; }
        public string? StoreName { get; set; }
        public string? StoreUrl { get; set; }
        public string? StoreImage { get; set; }

        public string? SellerId { get; set; }
        public string? SellerFirstName { get; set; }
        public string? SellerLastName { get; set; }
        public string? SellerEmail { get; set; }
        public string? SellerPhone { get; set; }

        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public bool IsApproved { get; set; }

        public List<Product>? Products { get; set; }
        public List<ImageUrl>? ImageUrls { get; set; } = new List<ImageUrl>();
    }
}