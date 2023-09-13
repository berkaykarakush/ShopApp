namespace PresentationLayer.Models
{
    public class ListProductVM
    {
        public PageInfoVM? PageInfo { get; set; }
        public List<ProductVM>? Products { get; set; }
        public string? StoreName { get; set; }
        public string? StoreUrl { get; set; }
        public string? StoreImage { get; set; }
    }
}
