using EntityLayer;

namespace PresentationLayer.ViewModels
{
    public class CreateProductVM
    {
        public CreateProductVM()
        {
            SelectedCategories = new List<Category>();
            ImageUrls = new List<ImageUrl>();
            SalesCount = 0;
            Url = "";
            Price = 0;
            ProductImage = "";
            CreatedDate = "";
            UpdatedDate = "";
            Name = "";
            Description = "";
        }
        public double ProductId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int SalesCount { get; set; }
        public string Description { get; set; }
        public List<ImageUrl> ImageUrls { get; set; }
        public string ProductImage { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public List<Category> SelectedCategories { get; internal set; }
    }
}
