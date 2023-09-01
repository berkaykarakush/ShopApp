﻿namespace PresentationLayer.Models
{
    public class CreateBrandVM
    {
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public double BrandId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public List<ProductVM>? Products { get; set; }  
    }
}
