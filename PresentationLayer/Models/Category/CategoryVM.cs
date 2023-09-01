namespace PresentationLayer.Models
{
    public class CategoryVM
    {
        public double CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public List<ProductVM>? Products { get; set; }
    }
}
