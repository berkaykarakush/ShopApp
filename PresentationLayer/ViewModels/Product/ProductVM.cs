﻿using EntityLayer;
using PresentationLayer.Models;

namespace PresentationLayer.ViewModels  
{
    public class ProductVM
    {
        public double ProductId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public double Price { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public int Quantity { get; set; }
        public int SalesCount { get; set; }
        public string? Description { get; set; }
        public string? ProductImage { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }

        public double BrandId { get; set; }
        public BrandVM? Brand { get; set; }

        public double? CategoryId { get; set; }
        public CategoryVM? Category { get; set; }

        public double? Category2Id { get; set; }
        public Category2VM? Category2 { get; set; }

        public List<ImageUrl>? ImageUrls { get; set; }
        public ICollection<CommentVM>? Comments { get; set; }
    }
}
