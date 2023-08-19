using PresentationLayer.ViewModels;

namespace PresentationLayer.Models
{
    public class ProductListViewModel
    {
        public PageInfoVM PageInfo { get; set; }
        public List<ProductVM> Products { get; set; }
    }
}
