using EntityLayer;

namespace PresentationLayer.ViewModels  
{
    public class ShopListVM
    {
        public double ProductId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int SalesCount { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public List<ImageUrl> ImageUrls { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
