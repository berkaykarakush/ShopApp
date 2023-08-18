using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using EntityLayer;

namespace PresentationLayer.ViewModels
{
    public class CategoryVM
    {
        public CategoryVM()
        {
            Random random = new Random();
            CategoryId = random.Next(111111111,999999999);
            Products = new List<Product>();
        }
        public double CategoryId { get; set; }
        public string? Name { get; set; }

        public string? Url { get; set; }
        public List<Product>? Products { get; set; }

        public static implicit operator CategoryVM(EditCategoryQueryResponse v)
        {
            CategoryVM categoryVM = new CategoryVM();

            categoryVM.CategoryId = v.CategoryId;
            categoryVM.Name = v.Name;
            categoryVM.Url = v.Url;
            categoryVM.Products = v.Products;

            return categoryVM;
        }

        public static implicit operator CategoryVM(EditCategoryCommandResponse r)
        {
            CategoryVM c = new CategoryVM();
            c.CategoryId = r.CategoryId;
            c.Name = r.Name;
            c.Url = r.Url;
            c.Products = r.Products;
            return c;
        }
    }
}
