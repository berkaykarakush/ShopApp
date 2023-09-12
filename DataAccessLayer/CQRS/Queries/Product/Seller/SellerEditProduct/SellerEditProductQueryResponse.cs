using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class SellerEditProductQueryResponse
    {
        public bool IsSuccess { get; set; }
        public double ProductId { get; set; } 
        public string? Name { get; set; }
        public string? Url { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public string? ProductImage { get; set; }

        public double? BrandId { get; set; }
        public double? CategoryId { get; set; }
        public double? Category2Id { get; set; }
        public double? StoreId { get; set; }

        public string? BrandName { get; set; }
        public string? CategoryName { get; set; }
        public string? Category2Name { get; set; }

        public List<ImageUrl>? ImageUrls { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Brand>? Brands { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Category2>? Categories2 { get; set; }
    }
}