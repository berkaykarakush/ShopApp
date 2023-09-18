namespace EntityLayer
{
    public class Store : BaseEntity
    {
        public double StoreId { get; set; } = new Random().Next(111111111, 999999999);
        public string? StoreName { get; set; }
        public string? StoreUrl { get; set; }
        public string? StoreImage { get; set; }

        public string? SellerId { get; set; }
        public string? SellerFirstName { get; set; }
        public string? SellerLastName { get; set; }
        public string? SellerEmail { get; set;}
        public string? SellerPhone { get; set; }

        public decimal StoreRate { get; set; }
        public int CommentCount { get; set; }
        public decimal StarCount { get; set; }

        public bool IsApproved { get; set; }

        public List<Order>? Orders { get; set; }
        public List<Product>?  Products { get; set; }
        public List<ImageUrl>? ImageUrls { get; set; } = new List<ImageUrl>();
    }
}
