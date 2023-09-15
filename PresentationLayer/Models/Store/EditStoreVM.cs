using EntityLayer;

namespace PresentationLayer.Models  
{
    public class EditStoreVM
    {
        public double StoreId { get; set; }
        public string? StoreName { get; set; }
        public string? StoreUrl { get; set; }
        public string? StoreImage { get; set; }
        public List<ImageUrl>? ImageUrls { get; set; }

        public string? SellerId { get; set; }
        public string? SellerFirstName { get; set; }
        public string? SellerLastName { get; set; }
        public string? SellerEmail { get; set; }
        public string? SellerPhone { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
