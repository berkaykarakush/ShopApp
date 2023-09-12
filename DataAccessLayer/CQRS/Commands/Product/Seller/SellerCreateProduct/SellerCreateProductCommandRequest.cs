using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerCreateProductCommandRequest: IRequest<SellerCreateProductCommandResponse>
    {
        public string? SellerId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public string? ProductImage { get; set; }

        public double BrandId { get; set; }
        public double CategoryId { get; set; }
        public double Category2Id { get; set; }
        public List<ImageUrl> ImageUrls { get; set; } = new List<ImageUrl>();
    }
}