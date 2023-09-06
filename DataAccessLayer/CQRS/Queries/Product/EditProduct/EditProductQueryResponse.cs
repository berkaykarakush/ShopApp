using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditProductQueryResponse
    {
        public double ProductId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public string? ProductImage { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public bool IsSuccess { get; set; }
        public double BrandId { get; set; }
        public double CategoryId { get; set; }
        public double Category2Id { get; set; }
        public string? BrandName { get; set; }
        public string? CategoryName { get; set; }
        public string? Category2Name { get; set; }
        public List<Category>? Categories { get; set; } = new List<Category>();
        public List<Category2>? Categories2 { get; set; } = new List<Category2>();
        public List<Brand>? Brands { get; set; } = new List<Brand>();
        public List<ImageUrl>? ImageUrls { get; set; } = new List<ImageUrl>();
    }
}