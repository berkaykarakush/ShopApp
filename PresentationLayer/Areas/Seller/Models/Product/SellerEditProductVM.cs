﻿using EntityLayer;
using PresentationLayer.Models;

namespace PresentationLayer.Areas.Seller.Models
{
    public class SellerEditProductVM
    {
        public double ProductId { get; set; } 
        public string? Name { get; set; }
        public string? Url { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public string? ProductImage { get; set; }

        public double BrandId { get; set; }
        public double? CategoryId { get; set; }
        public double? Category2Id { get; set; }

        public string? BrandName { get; set; }
        public string? CategoryName { get; set; }
        public string? Category2Name { get; set; }

        public List<ImageUrl>? ImageUrls { get; set; }
        public List<CategoryVM>? Categories { get; set; }
        public List<Category2VM>? Categories2 { get; set; }
        public List<BrandVM>? Brands { get; set; }
    }
}
