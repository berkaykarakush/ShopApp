using EntityLayer;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Models
{
    public class ProductDetailModel
    {
        public ProductVM Product { get; set; }
        public List<CategoryVM> Categories { get; set; }
    }
}
