using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class EditProductCommandRequest: IRequest<EditProductCommandResponse>
    {
        public double ProductId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public string? ProductImage { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public string? UpdatedDate { get; set; }

        public double CategoryId { get; set; }
        public double Category2Id { get; set; }
        public double BrandId { get; set; }
        public List<ImageUrl>? ImageUrls { get; set; } = new List<ImageUrl>();
    }
}