﻿using EntityLayer;

namespace PresentationLayer.Models
{
    public class ReadProductVm
    {
        public double ProductId { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public int Quantity { get; set; }
        public int? SalesCount { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public List<Category>? SelectedCategories { get; internal set; }
    }
}
