﻿using PresentationLayer.ViewModels;

namespace PresentationLayer.Models  
{
    public class UpdateBrandVM
    {
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public double BrandId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public ICollection<ProductVM>? Products { get; set; }
    }
}