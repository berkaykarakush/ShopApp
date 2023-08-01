using EntityLayer;

namespace PresentationLayer.Models
{
    public class ProductListViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Product> Products { get; set; }
    }
}
