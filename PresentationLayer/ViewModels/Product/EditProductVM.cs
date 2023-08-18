using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using EntityLayer;

namespace PresentationLayer.ViewModels
{
    public class EditProductVM
    {
        public EditProductVM()
        {
            SelectedCategories = new List<Category>();
            Categories = new List<Category>();
            ImageUrls = new List<ImageUrl>();
            Url = "";
            Price = 0;
            Name = "";
            Description = "";
            ProductImage = "";
            UpdatedDate = "";
        }
        public double ProductId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public List<ImageUrl> ImageUrls { get; set; }
        public string ProductImage { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public string UpdatedDate { get; set; }
        public List<Category> Categories { get; set; }
        public List<Category> SelectedCategories { get; internal set; }

        public static implicit operator EditProductVM(EditProductQueryResponse v)
        {
           EditProductVM editProductVM = new EditProductVM();
            editProductVM.ProductId = v.ProductId;
            editProductVM.Name = v.Name;
            editProductVM.Url = v.Url;
            editProductVM.Price = v.Price;
            editProductVM.Quantity = v.Quantity;
            editProductVM.Description = v.Description;
            editProductVM.ImageUrls = v.ImageUrls;
            editProductVM.ProductImage = v.ProductImage;
            editProductVM.IsApproved = v.IsApproved;
            editProductVM.IsHome = v.IsHome;
            editProductVM.UpdatedDate = v.UpdatedDate;
            editProductVM.Categories = v.Categories;
            editProductVM.SelectedCategories = v.SelectedCategories;
            return editProductVM;
        }

        public static implicit operator EditProductVM(EditProductCommandResponse response)
        {
            EditProductVM editProductVM = new EditProductVM();
            editProductVM.ProductId = response.ProductId;
            editProductVM.ImageUrls = response.ImageUrls;
            return editProductVM;
        }
    }
}
