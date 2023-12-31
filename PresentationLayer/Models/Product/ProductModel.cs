﻿using EntityLayer;
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
        public decimal? Price { get; set; }

        [Required]
        public int Quantity { get; set; }
        public int? SalesCount { get; set; }

        [Required]
        [DataType(DataType.Html)]
        public string? Description { get; set; }

        [DataType(DataType.ImageUrl)]
        public string? ProductImage { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<Category>? SelectedCategories { get; internal set; }

        public double BrandId { get; set; }
        public BrandVM? Brand { get; set; }
        public List<ImageUrl>? ImageUrls { get; set; }
        public List<ProductCategoryVM>?  ProductCategories { get; set; }
        public List<CommentVM>? Comments { get; set; }
    }
}
