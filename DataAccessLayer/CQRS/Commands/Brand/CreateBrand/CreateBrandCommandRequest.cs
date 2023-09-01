using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class CreateBrandCommandRequest: IRequest<CreateBrandCommandResponse>
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public List<Product>? Products { get; set; }
    }
}