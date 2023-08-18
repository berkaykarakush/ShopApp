using EntityLayer;

namespace DataAccessLayer.CQRS.Queries
{
    public class EditProductQueryResponse
    {
        public EditProductQueryResponse()
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
    }
}