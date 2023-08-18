using DataAccessLayer.CQRS.Queries;
using EntityLayer;

namespace PresentationLayer.ViewModels
{
    public class ListProductVM
    {
        public ListProductVM()
        {
            Products = new List<Product>();
        }
        public PageInfo? PageInfo { get; set; }
        public List<Product> Products { get; set; }

        public static implicit operator ListProductVM(ListProductQueryResponse v)
        {
            ListProductVM result = new ListProductVM();
            result.Products = v.Products;
            return result;
        }
    }
}
