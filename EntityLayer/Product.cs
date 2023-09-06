namespace EntityLayer
{
    public class Product
    {
        public double ProductId { get; set; } = new Random().Next(111111111, 999999999);
        public string? Name { get; set; }
        public string? Url { get; set; }
        public decimal Price { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public int Quantity { get; set; }
        public int SalesCount { get; set; }
        public string? Description { get; set; }
        public string? ProductImage { get; set; }
        public bool IsApproved { get; set; }

        public bool IsHome { get; set; }
        public decimal ProductRate { get; set; }
        public int CommentCount { get; set; }
        public int StarCount { get; set; }

        public double BrandId { get; set; }
        public Brand? Brand { get; set; }

        public double? CategoryId { get; set; }
        public Category? Category { get; set; }

        public double? Category2Id { get; set; }
        public Category2? Category2 { get; set; }

        public List<ImageUrl>? ImageUrls { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
