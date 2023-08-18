using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditProductCommandRequest: IRequest<EditProductCommandResponse>
    {
        public EditProductCommandRequest()
        {
            SelectedCategories = new List<ProductCategory>();
            ImageUrls = new List<ImageUrl>();
            CategoryIds = new List<double>();
            Url = "";
            Description = "";
            Name = "";
            Price = 0;
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
        public List<double> CategoryIds { get; set; }
        public List<ProductCategory>? SelectedCategories { get; internal set; }
    }
}