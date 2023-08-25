using PresentationLayer.ViewModels;

namespace PresentationLayer.Models  
{
    public class ListBrandVM
    {
        public ICollection<BrandVM> Brands { get; set; }
    }
}
