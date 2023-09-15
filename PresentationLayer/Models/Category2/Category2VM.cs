using EntityLayer;

namespace PresentationLayer.Models
{
    public class Category2VM
    {
        public double Category2Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public DateTime? CratedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<Product>? Products { get; set; }
    }
}
