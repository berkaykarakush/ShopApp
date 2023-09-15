namespace PresentationLayer.Models
{
    public class BrandVM
    {
        public double BaseEntityId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public double BrandId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public List<ProductVM>? Products { get; set; }  
    }
}
