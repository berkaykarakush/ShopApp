using EntityLayer;

namespace PresentationLayer.Models
{
    public class CategoryListViewModel
    {
        public CategoryListViewModel()
        {
            Categories = new List<Category>();
        }
        public List<Category> Categories { get; set; }

    }
}
