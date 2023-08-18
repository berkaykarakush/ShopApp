using MediatR;

namespace DataAccessLayer.CQRS.Commands
{
    public class DeleteCategoryCommandRequest: IRequest<DeleteCategoryCommandResponse>
    {
        public double categoryId { get; set; }
    }
}