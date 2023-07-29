using EntityLayer;

namespace PresentationLayer.VIewModels
{
    public class ProductListViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Product> Products { get; set; }
    }
}
