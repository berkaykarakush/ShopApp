using EntityLayer;
using MediatR;

namespace DataAccessLayer.CQRS.Commands 
{ 
    public class CreateCategoryCommandRequest:IRequest<CreateCategoryCommandResponse>
    {
        public double CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public List<Product>? Products { get; set; }
    }
}