namespace EntityLayer
{
    public class Product
    {
        public Product()
        {
            ProductId = new Random().Next(111111111, 999999999);
            ProductCategories = new List<ProductCategory>();
            ImageUrls = new List<ImageUrl>();
        }
        public double ProductId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public double Price { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public int Quantity { get; set; }
        public int SalesCount { get; set; }
        public string? Description { get; set; }
        public string? ProductImage { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public double BrandId { get; set; }
        public Brand? Brand { get; set; }
        public List<ImageUrl>? ImageUrls { get; set; }
        public List<ProductCategory>? ProductCategories { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
