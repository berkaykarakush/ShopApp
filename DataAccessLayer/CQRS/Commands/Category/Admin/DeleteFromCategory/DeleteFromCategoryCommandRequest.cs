using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteFromCategoryCommandRequest:IRequest<DeleteFromCategoryCommandResponse>
    {
        public double productId { get; set; }
        public double categoryId { get; set; }
    }
}