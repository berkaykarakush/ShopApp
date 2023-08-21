using PresentationLayer.ViewModels;

namespace PresentationLayer.Models
{
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
            Products = new List<ProductVM>();
            PageInfo = new PageInfoVM();
        }
        public PageInfoVM PageInfo { get; set; }
        public List<ProductVM> Products { get; set; }
    }
}
