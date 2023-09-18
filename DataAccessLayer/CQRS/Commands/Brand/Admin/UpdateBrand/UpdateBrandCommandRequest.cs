using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class UpdateBrandCommandRequest: IRequest<UpdateBrandCommandResponse>
    {
        public double BrandId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public List<Product>? Products { get; set; }
    }
}