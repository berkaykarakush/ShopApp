using EntityLayer;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Display(Prompt = "Enter your product name")]
        public string Name { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
