using EntityLayer;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class ProductModel
    {
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        [MinLength(1)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public string? Url { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double? Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Html)]
        public string Description { get; set; }
        
        [DataType(DataType.ImageUrl)]
        public string? ImageUrl { get; set; }
        
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<Category>? SelectedCategories { get; internal set; }
    }
}
