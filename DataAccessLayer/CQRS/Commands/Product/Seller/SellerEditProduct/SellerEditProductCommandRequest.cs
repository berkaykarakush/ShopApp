using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class SellerEditProductCommandRequest: IRequest<SellerEditProductCommandResponse>
    {
        public double ProductId { get; set; }
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public decimal Price { get; set; }
        public string? UpdatedDate { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public string? ProductImage { get; set; }

        public double BrandId { get; set; }
        public double CategoryId { get; set; }
        public double Category2Id { get; set; }
        public double StoreId { get; set; }
        public List<ImageUrl>? ImageUrls { get; set; }
    }
}