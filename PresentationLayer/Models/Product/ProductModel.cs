using EntityLayer;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class ProductModel
    {
        [Required]
        public double ProductId { get; set; }
        
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
        public int? SalesCount { get; set; }

        [Required]
        [DataType(DataType.Html)]
        public string Description { get; set; }
        
        [DataType(DataType.ImageUrl)]
        public string? ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public List<Category>? SelectedCategories { get; internal set; }
    }
}
