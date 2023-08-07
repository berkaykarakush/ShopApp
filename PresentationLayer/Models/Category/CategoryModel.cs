using EntityLayer;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Category name 5-100 karakter arasinda olmalidir")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Url is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Url 5-100 karakter arasinda olmalidir")]
        public string? Url { get; set; }

        public List<Product>? Products { get; set; }
    }
}
