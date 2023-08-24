using EntityLayer;

namespace PresentationLayer.ViewModels
{
    public class CategoryVM
    {
        public CategoryVM()
        {
            Random random = new Random();
            CategoryId = random.Next(111111111,999999999);
        }
        public double CategoryId { get; set; }
        public string? Name { get; set; }

        public string? Url { get; set; }
        public List<ProductVM>? Products { get; set; }
        public List<ProductCategory>? ProductCategories { get; set; }
    }
}
