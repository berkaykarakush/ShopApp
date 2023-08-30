using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class CreateProductCommandRequest: IRequest<CreateProductCommandResponse>
    {
        public CreateProductCommandRequest()
        {
            SelectedCategories = new List<Category>();
            ImageUrls = new List<ImageUrl>();
            Random random = new Random();
            ProductId = random.Next(111111111,999999999);
            Url = "";
            Price = 0;
            SalesCount = 0;
            CreatedDate = "";
            UpdatedDate = "";
            ProductImage = "";
        }
        public double ProductId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int SalesCount { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public List<ImageUrl> ImageUrls { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public List<Category> SelectedCategories { get; internal set; }
        public double CategoryId { get; set; }
        public double BrandId { get; set; }
    }
}
