using EntityLayer;
using PresentationLayer.Models;
using System.Reflection;

namespace PresentationLayer.ViewModels
{
    public class CreateProductVM
    {
        public CreateProductVM()
        {
            SelectedCategories = new List<CategoryVM>();
            ImageUrls = new List<ImageUrl>();
        }
        public double ProductId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int? SalesCount { get; set; }
        public string? Description { get; set; }
        public double CategoryId { get; set; }
        public List<ImageUrl>? ImageUrls { get; set; }
        public string? ProductImage { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public string? CreatedDate { get; set; }
        public List<CategoryVM>? SelectedCategories { get; internal set; }
        public List<CategoryVM>? Categories { get; set; }
        public List<BrandVM> Brands { get; set; }
        public double BrandId { get; set; }
    }
}
