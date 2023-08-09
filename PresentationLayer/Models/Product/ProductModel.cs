using EntityLayer;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Display(Prompt = "Enter your product name")]
        [Required(ErrorMessage = "Name alani bos birakilamaz")]
        [StringLength(60, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Price alani bos birakilamaz")]
        [Range(1, 999999999, ErrorMessage = "Price 1'den az olamaz")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Description alani bos birakilamaz")]
        [StringLength(240, MinimumLength = 3)]
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public List<Category>? SelectedCategories { get; set; }
    }
}
