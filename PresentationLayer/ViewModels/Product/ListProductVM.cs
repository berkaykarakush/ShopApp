namespace PresentationLayer.ViewModels
{
    public class ListProductVM
    {
        public ListProductVM()
        {
            Products = new List<ProductVM>();
        }
        public PageInfoVM? PageInfo { get; set; }
        public List<ProductVM> Products { get; set; }
    }
}
