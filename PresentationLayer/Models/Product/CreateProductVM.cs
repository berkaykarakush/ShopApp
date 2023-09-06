using EntityLayer;

namespace PresentationLayer.Models  
{
    public class CreateProductVM
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? SalesCount { get; set; }
        public string? Description { get; set; }
        public string? ProductImage { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public string? CreatedDate { get; set; }

        public double BrandId { get; set; }
        public double CategoryId { get; set; }
        public double Category2Id { get; set; }
        public List<ImageUrl>? ImageUrls { get; set; }
        public List<CategoryVM>? Categories { get; set; }
        public List<Category2VM>? Categories2 { get; set; }
        public List<BrandVM>? Brands { get; set; }
    }
}
